makecab.exe   /f   "cab.ddf"
signtool sign -f tinyfx.pfx -p ourgame TinyFxActiveX.CAB
del "setup.inf"
del "setup.rpt"