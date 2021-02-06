# WorldHeightmapForFAF
A Tool that pulls Google Maps elevation data to create heightmaps for FAF mapping

## Help Information
1. This application requires a Google API key. Follow [these instructions](https://developers.google.com/maps/documentation/elevation/get-api-key) to get one.
2. This application requires enabling the Google Elevation API. You get $200 in credit each month, and if you dont add a credit card it will not charge you, it just wont work. See instructions on how to enable the API [here](https://developers.google.com/maps/documentation/javascript/elevation#GetStarted)
## Live Data
Latitude and Longitude can either be lat/long pairs you get off google maps by right clicking and hitting the button that looks like this: `35.98800489312466, -78.88236362690753` and placing the first value in the latitude box and the second in the longitude box. Or, you can get the values from something like google earth where you are given latitude and longitude in degrees, minutes, seconds like so:  ` 0° 3'26.35"S, 129°31'52.34"E`. Again, first value to the latitude and second to the longitude.

## Saved Data
The application comes with some pre-saved datasets that you can play around with (without needing an API key). Once you run the application with a point from the live data section you can save the elevation points and fiddle with settings without having to make API requests again.

## Water Settings
Automatic water won't change the heightmap, just give you values. Flatten will remove all detected water values from the map, making its bottom flat.

## Squash Settings
These settings control how the application will attempt to get the distance between the min and max points under 50. Compress will compress the entire map until it fits, while flatten will just chop off all values past the min and max values.

The Squish Until box controls when the initial fit algorithm will stop. It is recommended to keep this at 80 for any first runs with the API, but feel free to change it when editing saved data (or live data if that suits you).

## Smoothing
How the application smooths the elevation to make it more fit for play.

### Normal 
Uses a normal distribution (Gaussian Kernel) to smooth the map.

### Round
Rounds all values to the nearest provided value. The default is `0.2500`, so all points would be rounded to the nearest `0.2500`

### Combined
The combined pass runs the Round smooth a single time, then the Normal smoothing for however many passes were set.

## Generated Automatic Water Values
These values are the suggested water values for the map to use. The files are saved independently inside the selected folder.

## Save Button
Opens a save dialog that has some extra settings.

### Include Extra Data
Saves some extra data such as the raw elevation data, modified elevation data, and the preview .bmp you see in the application. Does not save a dataset to the Saved Data tab.

### Save Elevation Dataset
Saves the set of elevation points for use again in the Saved Data tab.
