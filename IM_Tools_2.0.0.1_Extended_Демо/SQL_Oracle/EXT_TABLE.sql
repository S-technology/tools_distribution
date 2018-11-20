CREATE OR REPLACE PACKAGE CUSTOM.EXT_TABLE
IS
   PROCEDURE crt (table_name IN VARCHAR2, comm_str IN VARCHAR2, delimiter IN VARCHAR2, rowdelimiter IN VARCHAR2, blobparams IN VARCHAR2);
   PROCEDURE del (table_name_del IN VARCHAR2);
END EXT_TABLE;
/

GRANT EXECUTE ON CUSTOM.EXT_TABLE TO PUBLIC;
CREATE OR REPLACE PACKAGE BODY CUSTOM.EXT_TABLE
IS
PROCEDURE crt (table_name IN VARCHAR2, comm_str IN VARCHAR2, delimiter IN VARCHAR2, rowdelimiter IN VARCHAR2, blobparams IN VARCHAR2)
IS
    BEGIN
        execute immediate
        'CREATE TABLE EXT'||table_name||'('
        ||comm_str||
        ') ORGANIZATION EXTERNAL (
        TYPE ORACLE_LOADER
        DEFAULT DIRECTORY IMPDIR
        ACCESS PARAMETERS(
        RECORDS DELIMITED BY '||rowdelimiter||' BADFILE ''inu'||table_name||'.bad''
        LOGFILE ''inu'||table_name||'.log''
        FIELDS TERMINATED BY '''||delimiter||''' LDRTRIM'
       ||blobparams||
       ' ) LOCATION (
        ''inu'||table_name||'.dat''
        )
        ) REJECT LIMIT UNLIMITED';
        execute immediate 'GRANT ALTER, SELECT ON CUSTOM.EXT'||table_name||' TO PUBLIC';
END;
PROCEDURE del (table_name_del IN VARCHAR2)
IS
    BEGIN
        execute immediate 'DROP TABLE '||table_name_del||' CASCADE CONSTRAINTS';
END;
END EXT_TABLE;
/

GRANT EXECUTE ON CUSTOM.EXT_TABLE TO PUBLIC;