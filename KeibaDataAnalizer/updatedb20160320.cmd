@echo off
cd /d %~dp0
sqlite3.exe %1 < updatedb20160320.sql
pause