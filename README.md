# AOGConfigOMatic
A helper to easily flash the Teensy for agOpenGPS

[![Build and release](https://github.com/lansalot/AOGConfigOMatic/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/lansalot/AOGConfigOMatic/actions/workflows/dotnet-desktop.yml)

First of all - full credit to https://github.com/luni64/TeensySharp for this excellent library that makes flashing the Teensy super-simple! And to Jaap Van Handel for his excellent F9P configuration code !

Go to the [Releases](https://github.com/lansalot/AOGConfigOMatic/releases) page and download the latest!

## Reason for creation

People have had issues with various versions of TeensyDuino (specifically, versions higher than 1.57 causing boot loops) and also in locating different versions of the firmware for specific situations. Also, the F9P configuration is prone to error, as U-Center is not the most friendly of apps at times.

This tool aims to simplify all that. Go to the Releases section and download the big AOGConfigOMatic zip file, unzip it, and run the AOGConfigOMatic.exe file.

When you run it, you'll see the following:

(If you don't have a Teensy plugged in, that section will be blank of course). If you've never ran this before, you should Refresh the list of available firmware, so press that Refresh List button at the top.


The list is retrieved from github and saved locally as Firmwares.csv in the same folder as the program (see below for how you can add your own to this list). If you have any firmwares that should be added to the tool for everyone's benefit, please log an issue on github or message andyinv/lansalot on discourse/telegram etc.

Now, it's simply a matter of picking the firmware you wish - if it's not present already, it'll be downloaded - and press Program!


If anything goes wrong, make sure you don't have the Arduino IDE open or anything like that. And again, any issues, please let me know.

# How it works, and adding your own custom images for Teensy

Out of the box, the app doesn't know about any images, or where to find them. That's why it comes up empty and advises you to press Refresh.

When you do that, it'll connect to this repository and pull the CSV file and store it in the same folder as the app, populating the listbox with the entries in it. If you edit that CSV file, you can add your own firmwares to the list - just don't press Refresh again and it won't get overwritten by the original !

If the HEX file you want to flash isn't also in the same folder as the app, it'll pull it from the repo and cache it there. Once it has the CSV and the HEX files you're interested in, it will never need internet access again (until you press Refresh again of course). So this means that if you edit the CSV, and place additional HEX files in the folder, you can customise the list with your own local firmware images.
