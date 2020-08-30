<?php
    if(isset($_GET["spotify"]))
        exec("scripts\startSpotify.bat");
    else if(isset($_GET["turnOff"]))
        exec("scripts\\turnOffPC.bat");
    else if(isset($_GET["switchSleepMode"]))
        exec("scripts\switchSleepMode.bat");
    else if(isset($_GET["soundMuteUnmute"]))
        echo(exec("scripts\soundMuteUnmute.bat"));
    else if(isset($_GET["volumeDown"]))
        exec("scripts\\volumeDown.bat");
    else if(isset($_GET["volumeUp"]))
        exec("scripts\\volumeUp.bat");

    echo("\n");
    var_dump($_REQUEST);
?>