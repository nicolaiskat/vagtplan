CREATE DATABASE vagtplan

CREATE TABLE volunteer (
	volunteer_id bigserial CONSTRAINT volunteer_key PRIMARY KEY,
	first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
	mobile bigint NOT NULL,
	username varchar(50) NOT NULL,
    password varchar(200) NOT NULL,
    password_salt varchar(50) NOT NULL,
    password_hash_algorithm varchar(50) NOT NULL,
	access smallint NOT NULL DEFAULT 0,
    hours smallint NOT NULL DEFAULT 0,
    points smallint NOT NULL DEFAULT 0
);

CREATE TABLE coordinator (
	coordinator_id bigserial CONSTRAINT coordinator_key PRIMARY KEY,
	first_name varchar(50) NOT NULL,
    last_name varchar(50) NOT NULL,
	mobile bigint NOT NULL,
	username varchar(50) NOT NULL,
    password varchar(200) NOT NULL,
    password_salt varchar(50) NOT NULL,
    password_hash_algorithm varchar(50) NOT NULL,
	access smallint NOT NULL DEFAULT 1
);

CREATE TABLE coupon (
	coupon_id bigserial CONSTRAINT coupon_key PRIMARY KEY,
	description varchar(200) NOT NULL,
	price smallint NOT NULL
);

CREATE TABLE job (
	job_id bigserial CONSTRAINT job_key PRIMARY KEY,
	area varchar(50) NOT NULL
);

CREATE TABLE shift (
	shift_id bigserial CONSTRAINT shift_key PRIMARY KEY,
	start_time timestamp NOT NULL,
	end_time timestamp NOT NULL,
	description varchar(200) NOT NULL,
    taken boolean NOT NULL DEFAULT false,
    volunteer_id bigint REFERENCES volunteer (volunteer_id),
    job_id bigint NOT NULL REFERENCES job (job_id)
);

CREATE TABLE coupon_volunteer (
    coupon_id bigint REFERENCES coupon (coupon_id),
    volunteer_id bigint REFERENCES volunteer (volunteer_id)
);

CREATE TABLE logger (
    logger_id bigserial CONSTRAINT logger_key PRIMARY KEY,
    event_type varchar(50) NOT NULL,
    table_name varchar(50) NOT NULL,
    user_role varchar(50) NOT NULL,
    log_date timestamptz NOT NULL DEFAULT now()
); 


CREATE OR REPLACE FUNCTION public.log_data() 
   RETURNS trigger 
   LANGUAGE 'plpgsql' 
AS $BODY$ 
BEGIN 
INSERT INTO logger (event_type, table_name, user_role, log_date) 
  VALUES (TG_OP, TG_TABLE_NAME, CURRENT_USER, now()); 
 
RETURN NEW; 
END; 
$BODY$;


CREATE TRIGGER log_data_volunteer 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.volunteer
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 

CREATE TRIGGER log_data_coordinator 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.coordinator
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 

CREATE TRIGGER log_data_shift 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.shift
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 

CREATE TRIGGER log_data_job 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.job
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 

CREATE TRIGGER log_data_coupon 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.coupon
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 

CREATE TRIGGER log_data_coupvolu 
   AFTER INSERT OR UPDATE OR DELETE 
   ON public.coupon_volunteer
   FOR EACH ROW EXECUTE FUNCTION public.log_data(); 


    INSERT INTO volunteer (first_name, last_name, mobile, username, password, password_salt, password_hash_algorithm)
    VALUES	('Ole', 'Olsen', 98764523, 'Ole123', 'password', 'password', 'password');

    INSERT INTO coordinator (first_name, last_name, mobile, username, password, password_salt, password_hash_algorithm)
    VALUES	('Ole', 'Olsen', 98764523, 'Ole123', 'password', 'password', 'password');



CREATE OR REPLACE PROCEDURE add_volunteer(firstname TEXT, lastname TEXT, mobil TEXT, user_name TEXT, pass TEXT)
LANGUAGE 'plpgsql'
AS $BODY$ 
DECLARE
salt text;
BEGIN 
	IF EXISTS (SELECT FROM volunteer WHERE username = user_name) THEN
		RAISE EXCEPTION 'Dette username er allerede i brug: %', user_name;
	ELSE
		IF EXISTS (SELECT FROM coordinator WHERE username = user_name) THEN
			RAISE EXCEPTION 'Dette username er allerede i brug: %', user_name;
		ELSE
			SELECT gen_salt('md5') into salt;
			INSERT INTO volunteer (first_name, last_name, mobile, username, password, password_salt, password_hash_algorithm) 
  				VALUES (firstname, lastname, mobil, user_name, crypt(pass, salt), salt, 'md5');
		END IF;
	END IF;
END 
$BODY$; 


CALL add_volunteer('Andreas', 'Aagaard', 60351677, 'AndreasAa', 'password')

CREATE OR REPLACE FUNCTION check_pass(user_name text, pass text)
    RETURNS integer
    LANGUAGE 'plpgsql'
AS $BODY$
DECLARE
salt TEXT
BEGIN
IF EXISTS (SELECT FROM volunteer WHERE username = user_name) THEN
		RAISE EXCEPTION 'Dette username er allerede i brug: %', user_name;
	ELSE
		IF EXISTS (SELECT FROM coordinator WHERE username = user_name) THEN
		ELSE
            RAISE EXCEPTION 'Dette username er findes ikke: %', user_name;

		END IF;
	END IF;

END
$BODY$;

CREATE OR REPLACE FUNCTION public.check_login(
	un character varying,
	pw character varying)
    RETURNS integer
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE salted varchar;
BEGIN
	IF EXISTS
		(SELECT * 
		 FROM volunteer
		 WHERE username = un) THEN 
			SELECT password_salt 
			FROM volunteer
			WHERE username = un
			INTO salted;
			IF (crypt(pw, salted) = (SELECT password FROM volunteer WHERE username = un)) THEN
				RETURN (SELECT access FROM volunteer WHERE username = un);
			ELSE
				RAISE EXCEPTION 'Fokert login';
			 END IF;
		END IF;
	IF EXISTS
		(SELECT * 
		 FROM coordinator
		 WHERE username = un) THEN 
			SELECT password_salt 
			FROM coordinator
			WHERE username = un
			INTO salted;
			IF (crypt(pw, salted) = (SELECT password FROM coordinator WHERE username = un)) THEN
				RETURN (SELECT access FROM coordinator WHERE username = un);
			ELSE
				RAISE EXCEPTION 'Fokert login';
			END IF;
		ELSE
			RAISE EXCEPTION 'Forkert login';
	  END IF;

END
$BODY$;


CREATE OR REPLACE PROCEDURE add_job(_area text)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    INSERT INTO job (area) 
        VALUES (_area)
END 
$BODY$;

CREATE OR REPLACE PROCEDURE delete_job(id int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    DELETE FROM job WHERE job_id = id; 
END 
$BODY$;  

CREATE OR REPLACE PROCEDURE add_coupon(_description text, _price int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    INSERT INTO coupon (description, price) 
        VALUES (_description, _price); 
END;
$BODY$;  


CREATE OR REPLACE PROCEDURE delete_volunteer(id int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    DELETE FROM volunteer WHERE volunteer_id = id; 
END 
$BODY$;  

CREATE OR REPLACE PROCEDURE edit_volunteer(id int, firstname text, lastname text, mobil text)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    UPDATE volunteer
    SET first_name = firstname,
    last_name = lastname,
    mobile = mobil
    
    WHERE volunteer_id = id;
END 
$BODY$;  

CREATE OR REPLACE PROCEDURE add_coupon(_description text, _price int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    INSERT INTO coupon (description, price) 
        VALUES (_description, _price); 
END;
$BODY$;  

CREATE OR REPLACE PROCEDURE delete_shift(id int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    DELETE FROM shift WHERE shift_id = id; 
END 
$BODY$;  


CREATE OR REPLACE PROCEDURE edit_coupon(id int, _description text, _price int)
LANGUAGE 'plpgsql'
AS $BODY$ 
BEGIN 
    UPDATE coupon
    SET description = _description,
    price = _price
    
    WHERE coupon_id = id;
END 
$BODY$;  