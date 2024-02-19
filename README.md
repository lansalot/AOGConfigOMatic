# AOGConfigOMatic
A helper to easily flash the Teensy for agOpenGPS

[![Build and release](https://github.com/lansalot/AOGConfigOMatic/actions/workflows/main.yml/badge.svg)](https://github.com/lansalot/AOGConfigOMatic/actions/workflows/main.yml)

First of all - full credit to https://github.com/luni64/TeensySharp for this excellent library that makes flashing the Teensy super-simple! And to Jaap van den Handel for his excellent F9P configuration code !

Go to the [Releases](https://github.com/lansalot/AOGConfigOMatic/releases) page and download the latest! Unzip it and run the main program.

## Reason for creation

People have had issues with various versions of TeensyDuino (specifically, versions higher than 1.57 causing boot loops) and also in locating different versions of the firmware for specific situations. Also, the F9P configuration is prone to error, as U-Center is not the most friendly of apps at times.

# Flashing GPS/F9P

This tool aims to simplify all that. Go to the Releases section and download the big AOGConfigOMatic zip file, unzip it, and run the AOGConfigOMatic.exe file.

When you run it, you'll see the following:

![image](https://github.com/lansalot/AOGConfigOMatic/assets/9885921/ed33c2d5-e99e-44c8-a0e0-9a0c44953d5c)

There are two tabs at the top, Ublox and Teensy - switch between the two depending on what you have plugged in. I'd advise only plugging in one device at a time however.

If you plug a ublox F9P in after starting the program, it won't show up automatically (unlike the Teensy, which will). Press Rescan Ports to look for it. Then, connect to the device.

![image](https://github.com/lansalot/AOGConfigOMatic/assets/9885921/80d116f7-a3e6-4f72-a1f5-30b55bc3ca7b)

If it's a cold start for the F9P, the messages that fly by won't include a location (yet). Note the green at top right (1) - indicating we are on version 1.13 of firmware. The configuration only works with version 1.13, and if it's not that, you'll be advised to downgrade it first - which you do by pressing "Flash firmware"(2). Look for a box that pops up and indicates the flashing progress, be patient, it can take a couple of minutes and don't interrupt it.

Once that's done, you can send the configuration with the "Configure F9P"(3) button. Before you do that, ensure you've picked the right configuration button from the list below(4).

All being well, the progress bar at the bottom will fill up and seconds later, you'll have just GNGGA and GNVTG flying by at a rate of about 10 per second. You're done!

![image](https://github.com/lansalot/AOGConfigOMatic/assets/9885921/106a04f4-902c-4b5e-921f-48bfa5db6a38)

Now, if you need to, either do your other F9P (if you're using Dual), or switch to the Teensy tab.

# Flashing Teensy

If you've never ran this before, you should Refresh the list of available firmware, so press that Refresh List button at the top.

![image](https://github.com/lansalot/AOGConfigOMatic/assets/9885921/c3cdb7c5-ce2a-4c03-a63a-4007334aa0d1)

The list is retrieved from github and saved locally as Firmwares.csv in the same folder as the program (see below for how you can add your own to this list). If you have any firmwares that should be added to the tool for everyone's benefit, please log an issue on github or message andyinv/lansalot on discourse/telegram etc.

Plug in your Teensy and you'll see it appear in the list.

Now, it's simply a matter of picking the firmware you wish - if it's not present already, it'll be downloaded - and press Program!

![image](https://github.com/lansalot/AOGConfigOMatic/assets/9885921/a92b232c-ac12-458f-94ef-65fe37102d60)

If anything goes wrong, make sure you don't have the Arduino IDE open or anything like that. And again, any issues, please let me know.

# How it works, and adding your own custom images for Teensy

Out of the box, the app doesn't know about any images, or where to find them. That's why it comes up empty and advises you to press Refresh.

When you do that, it'll connect to this repository and pull the CSV file and store it in the same folder as the app, populating the listbox with the entries in it. If you edit that CSV file, you can add your own firmwares to the list - just don't press Refresh again and it won't get overwritten by the original !

If the HEX file you want to flash isn't also in the same folder as the app, it'll pull it from the repo and cache it there. Once it has the CSV and the HEX files you're interested in, it will never need internet access again (until you press Refresh again of course). So this means that if you edit the CSV, and place additional HEX files in the folder, you can customise the list with your own local firmware images.
