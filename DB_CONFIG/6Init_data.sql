INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'David', 'Cadete', 'root', '1');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Luis', 'Oficial de Policia', 'root', '2');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Juan', 'Detective', 'root', '3');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Paco', 'Inspector', 'root', '3');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Jose', 'Teniente', 'root', '4');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Mario', 'Comandante', 'root', '4');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Gama', 'Comisionado', 'root', '5');
INSERT INTO TJPD.OFFICER
VALUES (TJPD.OFFICER_SEQ.NEXTVAL, 'Alberto', 'Jefe de Policia', 'root', '6');


INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Robo'); 

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Asalto');

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Secuestro');
 
INSERT INTO TJPD.CRIME_TYPE
VALUES(TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Asesinato'); 

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Extorsion'); 

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Violacion'); 

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Abuso');

INSERT INTO TJPD.CRIME_TYPE
VALUES (TJPD.CRYME_TYPE_SEQ.NEXTVAL,'Fraude');


INSERT INTO TJPD.STATION
VALUES (TJPD.STATION_SEQ.NEXTVAL, 'TJPD', 'Av. Miguel Negrete, Centro, Zona Urbana Rio Tijuana, 22000 Tijuana, B.C.', 'Noroeste');

INSERT INTO TJPD.STATION
VALUES (TJPD.STATION_SEQ.NEXTVAL, 'CDMXPD', 'Av. Miguel Negrete, Centro, Zona Urbana Rio Tijuana, 22000 Ciudad de Mexico', 'Centro');

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 1,1);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 2,1);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 3,1);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 4,1);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 5,2);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 6,2);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 7,2);

INSERT INTO TJPD.OFFICER_STATION
VALUES (TJPD.OFFICER_STATION_SEQ.NEXTVAL, 8,2);


COMMIT;