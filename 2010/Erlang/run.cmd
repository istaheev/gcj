@echo off
erlc problem_C_1C.erl
if errorlevel 1 goto exit
erl -s  problem_C_1C main
:exit
