/********************************************************************************************************************************************
	Создание последовательности (для MSSQL 2012 и выше) или псевдопоследовательности (для MSSQL 2008 и ниже) с именем SEQ_TEMP_IMPORT.
	Последовательность используется в инструменте 'Обмен данными'.

	Внимание! 
	Скрипт запускается после работы Конфигуратора баз данных (т.е. базы данных уже созданы).
	Предполагается, что в Конфигураторе значение параметра “Id экземпляра проекта” задано как "PM_FROM_INSTALLER", поэтому по умолчанию имена БД :
		use PM_FROM_INSTALLER_data;
		use PM_FROM_INSTALLER_S_data;
	Если значение параметра “Id экземпляра проекта” другое, необходимо имена "по умолчанию" заменить на реальные имена БД -
		Например, если параметр “Id экземпляра проекта” задан как "MY_DB", имена баз будут:
		use MY_DB_data;
		use MY_DB_S_data;
********************************************************************************************************************************************/
declare @sver varchar(20)
	, @ver int
	, @id bigint = 0
	, @createText varchar(1000);

set @sver = convert(varchar(20), SERVERPROPERTY('ProductVersion'));
set @ver = convert(int, substring(@sver, 1, CHARINDEX('.', @sver) -1));

use PM_FROM_INSTALLER_data; --PM_FROM_INSTALLER_data при небходимости заменить на реальное имя _data БД

if exists (select 'x' from sysobjects obj where obj.name = 'IMPORT_EXEPTIONS_TEMP_IEXT' and obj.type = 'U')
	select @id = ISNULL(MAX(t.SESSION_ID_IEXT), 0) from IMPORT_EXEPTIONS_TEMP_IEXT t; 	
set @id = @id + 1;

if @ver > 10 --последовательность
begin
	if exists (select 'x' from sysobjects obj where obj.name = 'SEQ_TEMP_IMPORT' and obj.type = 'SO')
	begin
		set @createText = 'drop SEQUENCE [SEQ_TEMP_IMPORT]';
		exec (@createText);
	end;
	set @createText =
	' CREATE SEQUENCE [dbo].[SEQ_TEMP_IMPORT] AS [bigint] START WITH ' + CAST(@id as varchar(20)) 
	 + ' INCREMENT BY 1'
	 + ' MINVALUE -9223372036854775808'
	 + ' MAXVALUE 9223372036854775807'
	 + ' NO CACHE';
	exec (@createText);
	grant alter on [SEQ_TEMP_IMPORT] to rtime_dba;
	grant update on [SEQ_TEMP_IMPORT] to rtime_dba;
	grant update on [SEQ_TEMP_IMPORT] to custom;
end
else --псевдопоследовательность
begin 

	use PM_FROM_INSTALLER_S_data; --PM_FROM_INSTALLER_S_data при небходимости заменить на реальное имя _S_data БД

	if exists(select 'x' from S_TB_SEQ seq where seq.SEQ_NAME = 'SEQ_TEMP_IMPORT')
		update S_TB_SEQ set SEQ_VALUE = @id, INCREMENT_BY = 1
		where SEQ_NAME = 'SEQ_TEMP_IMPORT';
	else
		insert S_TB_SEQ (SEQ_NAME, INCREMENT_BY, SEQ_VALUE)
		values ('SEQ_TEMP_IMPORT', 1, @id);
end;
