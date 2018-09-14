#Hospital simulator


[TOCM]

### Features
- A program that simulates a hospital.
- **Treatment room:** a room has a unique name. A room can be equipped with a treatment machine. 
- **Treatment machine:** a treatment machine has a unique name and a capability. Capabilities can be Advanced or Simple. 
- **Doctor:** a doctor has a name and a set of roles. A role can be Oncologist or General Practitioner. 
- **Patient:** a patient has a name and a condition. 
- **Condition:** a condition can be Cancer or Flu. A cancer condition has a topography. Topographies can be Head & Neck or Breast. 
- **Consultation:** a consultation has a patient, doctor, treatment room, registration date and consultation date. 

-------------
### Business Rules
Each day, a number of patients are registered at the hospital. Each time a patient is registered, a consultation should be scheduled at the first available date.

- The consultation occurs in a treatment room with a doctor. 
- Cancer patients must see oncologists flu patients must see general practitioners.
- Oncologists must meet their patients in a room with a treatment machine. 
	* Head & Neck patients need a machine with Advanced capability. 
	* Breast patients need a treatment machine with Advanced or Simple capability.
- All consultations take a full day. A consultation may not be scheduled on the same day as the patient is registered. 
- Consultations may be scheduled on any calendar day. Resources may not be doublebooked.
-------------
API shall set up the hospital with its resources and simulate the flow of patient registrations.
- Patient registration 
- Get the list of registred patients 
- Get the list of scheduled consultations 
-------------
### Initialize the service with the following resources: 
```javascript
"Doctors" : [ 
  { "Name" : "John", "Roles" : [ "Oncologist" ] },  
  { "Name" : "Anna", "Roles" : [ "GeneralPractitioner" ] },  
  { "Name" : "Laura", "Roles" : [ "Oncologist", "GeneralPractitioner" ] }  
]  

"TreatmentMachines" : [  
  { "Name" : "MachineA", "Capability" : "Advanced" },  
  { "Name" : "MachineB", "Capability" : "Advanced" },  
  { "Name" : "MachineC", "Capability" : "Simple" }  
]  

"TreatmentRooms" : [  
  { "Name" : "RoomOne" },  
  { "Name" : "RoomTwo" }, 
  { "Name" : "RoomThree", "TreatmentMachine" : "MachineA" },  
  { "Name" : "RoomFour", "TreatmentMachine" : "MachineB" },  
  { "Name" : "RoomFive", "TreatmentMachine" : "MachineC" } 
] 
```# HospitalSimulator-with-Domain-Driven-Design
