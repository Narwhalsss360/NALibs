# NALibs - Working repository for all NALibs

# Logs
  [NColor](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NColor/)
  [NDefs](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NDefs/)
  [NFuncs](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NFuncs/)
  [NEvents](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NEvents/)
  [NHC-SR04](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NHC-SR04/)
  [NPush](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NPush/)
  [NRotary](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NRotary/)
  [NStreamCom](https://github.com/Narwhalsss360/NStreamCom/)
  [NTimer](http://downloads.arduino.cc/libraries/logs/github.com/Narwhalsss360/NTimer/)
  [NWire](https://github.com/Narwhalsss360/NWire/actions)

# Potential naming convention
## Global variables, functions. public Member functions, public member variables.
### *Camel Case with first letter lowercase*
  `addSketchBinding`
  `addIRQBinding`

## Backend API globals
### *Dunder lower case, words seperated with underscore*
  `__setup_irq_bindings__`
  `__irq_st__`

## Custom type, strucs and class names
### *Camel Case*
  `Push`
  `ReleasedEventArgs`
  `VoidFunctionVoid`

## Private member functions
### *Camel Case with first letter lowercase*
  `internalUpdateRouter`

## Private member variables
### *Camel Case with first letter being a descriptor, followed by underscore*
#### Member
  `m_Variable`
#### Static member
  `s_Variable`
