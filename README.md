# CPSC-481-Project
Itinerary app by Frank Guo, Jiexuan Li, Kate Rivera, Minnie Thai, and Sandesh Regmi

## Requirements
.NET 5.0 is required to run this WPF app.

## Setup
1. Download project.
2. Within the project folder, open the wpfApp1 folder.
3. Select trvlApp.sln to load the project in Visual Studio.
4. Run the build.

## Navigating The App
Click on "ITINERARY" or "MAP" to switch between pages.
### ON THE MAP PAGE
- Click and drag to view the map.
- Double-click on itinerary pins to view location details/reviews.
- **List of pins that work *(all contained in the initial view of the map)***: 
  - food_2 (bottom-left orange pin)
  - event_1 (bottom blue pin)
  - attraction_2 (top-left purple pin)
  - top green pin
- Adding itinerary item from map:
  1. Double-click on attraction_1 pin (Glenbow Museum)
  2. Click on + button
  3. Floppy disk to save (Note: will not actually save changes since data for items are hardcoded).
- If you are in the location details page, click the back button or out of the window to go back to the map page.
- Click on filter buttons to filter out pins.
- Search "bubble tea" (enter or search icon) to filter out "bubble tea places".
### ON THE ITINERARY PAGE
- **Adding an itinerary item:**
  - **Name:** Mcdonalds
  - **Location:** random
  - **Time:** 2:00 pm - 2:50 pm
  - **Type:** Restaurant
  - Floppy disk to save
  - Back button to go back to itinerary page.
- **Editing/Deleting an itinerary item:**
  - After adding Mcdonalds to itinerary, click "McDonalds" item to edit.
  - Floppy disk to save changes (Note: will not actually save changes since data for items are hardcoded).
  - Trash icon to delete.
- **Shared tab:**
  - In the Settings page, enter "123456" under **Import Share Code**.
  - Click icon next to it.
  - Clicking "OK" on the popup will take you back to the itinerary page containing the shared itinerary.
  - "Chinatown Shopping" itinerary item is clickable.

## XAML Pages Information
1. Page1.xaml is the map page.
2. Page2.xaml is the itinerary page.
3. SettingsPage.xaml is the settings page.
4. RestaurantPin.xaml contains an example of restaurant details.
5. EventPin.xaml containts an example of event details.
6. AttractionsPin.xaml contains an example of attraction details.
7. Itinerary_AddItineraryItem.xaml is the popup for adding itinerary items.

