/* Formatted on 5/28/2018 9:52:59 PM (QP5 v5.300) */
CREATE OR REPLACE PROCEDURE EDIT_PWD (OFFICER_NAME   IN VARCHAR2,
                                      OFFICER_PWD    IN VARCHAR2,
                                      OFFICER_NEWPWD   IN VARCHAR2)
AS
BEGIN
    UPDATE TJPD.OFFICER
       SET TJPD.OFFICER.OFFICER_PASSWORD = OFFICER_NEWPWD
     WHERE TJPD.OFFICER.OFFICER_NAME = OFFICER_NAME AND TJPD.OFFICER.OFFICER_PASSWORD = OFFICER_PWD AND ROWNUM = 1;

    COMMIT;
END EDIT_PWD;

CREATE OR REPLACE PROCEDURE CHECK_LOGIN (
    ONAME IN VARCHAR2,
    OPWD  IN VARCHAR2,
    DATAUSER OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN DATAUSER FOR
    SELECT *
      FROM TJPD.OFFICER O
      INNER JOIN TJPD.OFFICER_STATION OS
        ON O.OFFICER_ID = OS.OFFICER_ID
      INNER JOIN TJPD.STATION S
        ON OS.STATION_ID = S.STATION_ID	
     WHERE     O.OFFICER_NAME = ONAME
           AND O.OFFICER_PASSWORD = OPWD;
END CHECK_LOGIN;

CREATE OR REPLACE PROCEDURE SEARCH_USER (O_ID      IN     NUMBER,
                                         O_NAME    IN     VARCHAR2,
                                         O_RANK    IN     VARCHAR2,
                                         S_NAME    IN     VARCHAR2,
                                         S_ZONE    IN     VARCHAR2,
                                         SEARCHU      OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN SEARCHU FOR
        SELECT O.OFFICER_ID,
               O.OFFICER_NAME,
               O.OFFICER_RANK,
               S.STATION_NAME,
               S.STATION_ZONE
          FROM TJPD.OFFICER  O
               INNER JOIN TJPD.OFFICER_STATION OS
                   ON O.OFFICER_ID = OS.OFFICER_ID
               INNER JOIN TJPD.STATION S ON OS.STATION_ID = S.STATION_ID
         WHERE    (   O.OFFICER_NAME LIKE O_NAME
                   OR O.OFFICER_RANK LIKE O_RANK
                   OR S.STATION_NAME LIKE S_NAME
                   OR S.STATION_ZONE LIKE S_ZONE)
               OR O.OFFICER_ID = NVL (O_ID, O.OFFICER_ID);
END SEARCH_USER;

CREATE OR REPLACE PROCEDURE SEARCH_STATION (S_ID      IN     NUMBER,
                                            S_NAME    IN     VARCHAR2,
                                            S_ADR     IN     VARCHAR2,
                                            S_ZONE    IN     VARCHAR2,
                                            SEARCHS      OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN SEARCHS FOR
        SELECT *
          FROM TJPD.STATION S 
         WHERE    (  S.STATION_NAME LIKE S_NAME
                   OR S.STATION_ZONE LIKE S_ZONE
                   OR S.STATION_ADDRESS LIKE S_ADR)
               OR S.STATION_ID = NVL (S_ID, S.STATION_ID);
END SEARCH_STATION;

CREATE OR REPLACE PROCEDURE SEARCH_FIR (F_ID      IN     NUMBER,
                                        O_NAME    IN     VARCHAR2,
										O_RANK    IN     VARCHAR2,
                                        S_NAME    IN     VARCHAR2,
                                        S_ZONE    IN     VARCHAR2,
										F_DATE	  IN	 DATE,
										F_TIME	  IN	 VARCHAR2,
										F_PLACE	  IN	 VARCHAR2,
                                        SEARCHF      OUT SYS_REFCURSOR)
AS
BEGIN
    OPEN SEARCHF FOR
        SELECT *
          FROM TJPD.FIR F 
		  	   INNER JOIN TJPD.OFFICER  O
			   	   ON F.OFFICER_ID = O.OFFICER_ID
			   INNER JOIN TJPD.STATION  S
			   	   ON F.STATION_ID = S.STATION_ID   
         WHERE    (   O.OFFICER_NAME LIKE O_NAME
                   OR O.OFFICER_RANK LIKE O_RANK
		 		   OR S.STATION_NAME LIKE S_NAME
                   OR S.STATION_ZONE LIKE S_ZONE
				   OR F.INCIDENT_DATE LIKE F_DATE
				   OR F.INCIDENT_TIME LIKE F_TIME
                   OR F.INCIDENT_PLACE LIKE F_PLACE)
               OR F.FIR_ID = NVL (F_ID, F.FIR_ID);
END SEARCH_FIR;

SHOW ERRORS