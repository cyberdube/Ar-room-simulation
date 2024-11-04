# AR Room Simulation
This is a designing tool used to create 3D walls and insert in over an image using Google ARCore and Unity.


## Motivation
You just moved into a new home and the living room looks a bit empty. You are thinking of adding a new set of furniture but you can't decide on the color, size or style. 

With this tool you could quickly take a picture of your living room and place virtual furniture inside the room. 

## Deployment
Might need to install Android Studio with the Android SDK and JDK for exporting the app to an Android device.

For exporting an app to iOS, Xcode (11.3 or above) must be installed on a Mac running macOS 10.14 Mojave or later. An Apple Developer account is required for signing the application.


## Developement
The walls are made using 3d plane objects. The interaction between user and interface is made using the C# Scripting language. The Buttons and bottom menu is made with the UI Components found in the designing section in Unity.

## Application

### Creating the virtual environment

As you open the application, you have to choose an image from your gallery or take a picture from the application. 
Next, you will be presented with a default virtual room with the background image set as your room. This is where you could change the size of the walls to fit the background image. You could also chage the camera view by pressing the center sphere and dragging your finger to the left or right.

<img src="Resources/Walls.gif" >

### Adding the furniture

Now that you have setup your virtual room, it is time to find the furniture you are looking for. If you press the next button, you will be presented by a menu where you could search for and furniture you desire. Once you have tapped on a furniture piece, it will be loaded within the plane boundries. You could move it around and rotate it as you please. 
Share the eddited picture with your friends and famly members to ask their feedback before you make a final decision. 

<img src="Resources/Chair.gif" >

## Status of the Project

### What Works

* Detection of real world planes using ARCore
* Placement of furniture within the room environment
* Storing of images to be used at a later time
* User could manually resize wall planes 

### Future Work

The project can be scaled up so that more furniture could be saved withing the database. Currently only 1 piece of furniture is saved on the menu.

Once multiple furniture is stored, it could be compared to many stores selling some simmilar piece of furiture. This could be for price, color, size, conveniece and more.

Other user interface and user experience improvements can be implemented to make the app easier and more pleasing to use.

## Built with 

* Unity - Cross-platform real-time game engine developed by Unity Technologies
* ARCore - A software development kit developed by Google that allows for augmented reality applications to be built
* Microsoft Visual Studio - Integrated development environment for C# from Microsoft
* Visual Studio Code - An open source code editor developed by Microsoft
