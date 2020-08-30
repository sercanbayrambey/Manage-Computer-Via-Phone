@echo off
rem 65536 is 100%
rem device where zero is the default device
rem left and right
rem supports whole numbers only therefore throws "missing operator" error when specifying 655.36
set /a volume=%1 * 655
nircmd setvolume 0 %volume% %volume%