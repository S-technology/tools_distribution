-- ������ ����� ��� ������ ������� S_RESURS
GRANT EXECUTE ON SYS.DBMS_LOCK TO PUBLIC;

-- ������ ����� ��� ������ ������ INU.IMPORT
GRANT EXECUTE ON SYS.UTL_FILE TO PUBLIC;
ALTER SYSTEM SET utl_file_dir=* SCOPE=spfile;
GRANT CREATE ANY TABLE TO PUBLIC;
GRANT SELECT ANY DICTIONARY TO PUBLIC;

CREATE OR REPLACE DIRECTORY 
IMPDIR AS 
'C:\app\admin\oradata\IM_TOOLS\temp';


GRANT READ, WRITE ON DIRECTORY IMPDIR TO PUBLIC;
