# Intelligent Mobile Robot
Intelligent Navigation System of Mobile Robot.
<br/>[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.1317906.svg)](https://doi.org/10.5281/zenodo.1317906)

### Reference to:
Valentyn N Sichkar. Intelligent Navigation System of Mobile Robot // GitHub platform. DOI: 10.5281/zenodo.1317906

### Related works:
* The investigation of Reinforcement Learning for the tasks of shortest path planning is put in separate repository and is available here: https://github.com/sichkar-valentyn/Reinforcement_Learning_in_Python

* The research results for Neural Network Knowledge Based system for the tasks of collision avoidance is put in separate repository and is available here: https://github.com/sichkar-valentyn/Matlab_implementation_of_Neural_Networks

* The study of Semantic Representation of knowledge and querying of it through owl files with SPARQL is put in separate repository and is available here: https://github.com/sichkar-valentyn/System_programming_for_SPARQL_querying_with_interface_development_by_html_files

## Description
<b>Hardware</b> - Arduino Mega, Motor Shield L298P, DC Motors, Ultrasonic Sensors, Gyroscope, Laser Sensors, Cameras, Lidar Sensor, Bluetooth Module, Batteries, Six Wheel High Pass Base with Active Suspension.
<br/><b>Software</b> - C# via Visual Studio, Python, Arduino IDE, Android SDK, Matlab.
<br/><b>Developmet</b> - Algorithms for Overcoming Obstacles, Algorithms for Localization, Algorithms for Mapping, SLAM Algorithms.

## Content
* <a href="#Introduction">Introduction</a>
* <a href="#Connecting DC Motors">Connecting DC Motors</a>
* <a href="#More information about equipment">More information about equipment</a>
* <a href="#Adding FIVE Ultrasonic sensors US-015">Adding FIVE Ultrasonic sensors US-015</a>
* <a href="#Checking the abilities to stop before the possible collisions with obstacles">Checking the abilities to stop before the possible collisions with obstacles</a>
* <a href="#Adding TEN Ultrasonic sensors HC-SR04">Adding TEN Ultrasonic sensors HC-SR04</a>
* <a href="#Connecting two Arduino Mega together">Connecting two Arduino Mega together</a>
* <a href="#Checking the abilities to overcome obstacles">Checking the abilities to overcome obstacles</a>
* <a href="#Adding Gyroscope">Adding Gyroscope</a>
* <a href="#Adding Lidar Sensor">Adding Lidar Sensor</a>
* <a href="#Adding Camera">Adding Camera</a>

### <a name="Introduction">Introduction</a>
Explaining the main goals of the Project
<br/>https://www.youtube.com/watch?v=srEd8KEh2uo
<br>[![Main goals of the Project](https://img.youtube.com/vi/srEd8KEh2uo/0.jpg)](https://www.youtube.com/watch?v=srEd8KEh2uo)

### <a name="Connecting DC Motors">Connecting DC Motors</a>
Connecting and checking the High Pass Six Wheel Base - HPSWB - for simple commands to move
<br/>https://www.youtube.com/watch?v=Ux8xrQHnlzI
<br>[![Connecting_DC_Motors](https://img.youtube.com/vi/Ux8xrQHnlzI/0.jpg)](https://www.youtube.com/watch?v=Ux8xrQHnlzI)

### <a name="More information about equipment">More information about equipment</a>
General view of the Motor Shield L298P is shown below on the figure
![L298P](images/L298P.jpg)

<br/>The view from the top of Motor Shield L298P and showing the main connectors that are needed for the Project.
<br/>![L298P_top_view](images/L298P_top_view.png)

<br/>General view of the DC Motor
<br/>![DC_Motor](images/DC_Motors.png)

<br/>Connection DC Motors to the Shield
<br/>![Connection_DC_Motors](images/DC_Motors_7.png)

<br/>General view of the Bluetooth Module HC-06
<br/>![Bluetooth_Module_HC-06](images/Bluetooth_Module_HC-06.jpg)

<br/>Connection Bluetooth Module HC-06 to the Shield or Arduino
<br/>![Connection_Bluetooth_Module](images/HC-06_Connectors.jpg)

<br/>More about equipment
<br/>https://www.youtube.com/watch?v=6KQcZUehVFo
<br>[![Equipment](https://img.youtube.com/vi/6KQcZUehVFo/0.jpg)](https://www.youtube.com/watch?v=6KQcZUehVFo)

<br/>General view of the Ultrasonic Sensor US-015
<br/>![Ultrasonic_Sensor_US-015](images/General_View_of_US-015.jpg)

<br/>Connection Ultrasonic Sensor US-015 (or HC-SR04) to the Arduino
<br/>![Connection_Ultrasonic_Sensor](images/Connection_of_Ultrasonic_Sensor.png)

<br/>Equations for Ultrasonic Sensors, explaining how they work
<br/>![Equasions_for_Ultrasonic_Sensor](images/Equasions_for_Ultrasonic_Sensor.png)

### <a name="Adding FIVE Ultrasonic sensors US-015">Adding FIVE Ultrasonic sensors US-015</a>
Checking the environment around with Ultrasonic Sensors US-015
<br/>HPSWB with Ultrasonic Sensors - view from the front
![Front](images/SWB_with_Ultrasonic_Sensors_Front.jpg)

<br/>HPSWB with Ultrasonic Sensors - view from the back
![Back](images/SWB_with_Ultrasonic_Sensors_Back.jpg)

<br/>HPSWB with Ultrasonic Sensors - view from one side
![Side](images/SWB_with_Ultrasonic_Sensors_Side.jpg)

### Figure below shows the results of working system in Real Time by SPARQL Querying of the Knowledge Base
![SPARQL_Querying](images/SPARQL_Querying_of_KB.png)

### This figure shows the results of Neural Network Knowledge Base
![NNKB](images/Results_of_the_Neural_Network.png)

### <a name="Checking the abilities to stop before the possible collisions with obstacles">Checking the abilities to stop before the possible collisions with obstacles</a>
With the help of Ultrasonic Sensors and seeing the obstacles to avoid the collisions
<br/>https://www.youtube.com/watch?v=QVCCuo-QOwA
<br>[![Avoid_Collision](https://img.youtube.com/vi/QVCCuo-QOwA/0.jpg)](https://www.youtube.com/watch?v=QVCCuo-QOwA)

### <a name="Adding TEN Ultrasonic sensors HC-SR04">Adding TEN Ultrasonic sensors HC-SR04</a>
Checking the environment around with Ten Ultrasonic Sensors HC-SR04
<br/>HPSWB - view from the front
![Front](images/HPSWB_with_Ten_Ultrasonic_Sensors.jpg)

<img src="images/User_interface.gif" alt="User interface with ten ultrasonic sensors">

### <a name="Connecting two Arduino Mega together">Connecting two Arduino Mega together</a>
The way how to connect Master and Slave Arduino Mega together through Serial Port
<br/>![Two_Arduino_Mega](images/2ArduinoMega2560.png)

### <a name="Checking the abilities to overcome obstacles">Checking the abilities to overcome obstacles</a>
Implementing and testing Algorithms for HPSWB
<br/>https://www.youtube.com/watch?v=rjMo-d7WrMY
<br>[![Overcoming_Obstacle](https://img.youtube.com/vi/rjMo-d7WrMY/0.jpg)](https://www.youtube.com/watch?v=rjMo-d7WrMY)

<img src="images/Obstacle_overcoming.gif" alt="Obstacle overcoming">

### <a name="Adding Gyroscope">Adding Gyroscope</a>
Adding Gyroscope in order to rotate HPSWB precisely to a needed degree regardless of battery charge
<br/>_Coming soon_

### <a name="Adding Lidar Sensor">Adding Lidar Sensor</a>
Checking the environment with Lidar Sensor
<br/>_Coming soon_

### <a name="Adding Camera">Adding Camera</a>
Working with Computer Vision
<br/>_Coming soon_

<br/>

### MIT License
### Copyright (c) 2017-2018 Valentyn N Sichkar
### github.com/sichkar-valentyn
### Reference to:
Valentyn N Sichkar. Intelligent Navigation System of Mobile Robot // GitHub platform. DOI: 10.5281/zenodo.1317906
