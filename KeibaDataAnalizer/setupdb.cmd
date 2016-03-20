@echo off
cd /d %~dp0
del Keiba.sqlite
sqlite3.exe -init Keiba.sql Keiba.sqlite < nul
