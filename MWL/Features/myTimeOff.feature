Feature: myTimeOff
	As an Employee of Moneypenny
	I want to book time

@TimeOff @Holiday @BookingHoliday
Scenario: Booking a Holiday
	Given an employee logs into My Working Life
	When the employee goes to the holiday request screen
	And selects a day to book off
	Then books the Time Off
	And the employee logs out

@TimeOff @Holiday @HolidayBookingConflict
Scenario: Checking for a Holiday booking conflict
	Given an employee logs into My Working Life
	When the employee goes to the holiday request screen
	And selects a day to book off
	Then the employee fails to book the same day again
	And the employee logs out

@TimeOff @Holiday @CancellingABookedHoliday
Scenario: Cancelling a booked Holiday
	Given an employee logs into My Working Life
	When the employee goes to the holiday request screen
	Then cancels a booked holiday
	And the employee logs out

@TimeOff @Lieu @BookingTimeInLieu
Scenario: Booking Time in Lieu
	Given an employee logs into My Working Life
	When the employee goes to the Lieu request screen
	And selects a day to book off
	Then books the Time Off
	And the employee logs out

@TimeOff @Lieu @LieuBookingConflict
Scenario: Checking for Time in Lieu booking conflict 
	Given an employee logs into My Working Life
	When the employee goes to the Lieu request screen
	And selects a day to book off
	Then the employee fails to book the same day again
	And the employee logs out

@TimeOff @Lieu @CancellingTimeInLieu
Scenario: Cancelling booked Time In Lieu
	Given an employee logs into My Working Life
	When the employee goes to the Lieu request screen
	Then cancels the booked Time In Lieu
	And the employee logs out

@TimeOff @Appointment @BookingAppointment
Scenario: Booking an Appointment
	Given an employee logs into My Working Life
	When the employee goes to the Appointment request screen
	And selects a day to book off
	And enters Reason for the Appointment
	And enters Notes about the Appointment
	Then books the Time Off
	And the employee logs out

@TimeOff @Appointment @AppointmentBookingConflict
Scenario: Checking for a Appointment booking conflict 
	Given an employee logs into My Working Life
	When the employee goes to the Appointment request screen
	And selects a day to book off
	And enters Reason for the Appointment
	And enters Notes about the Appointment
	Then the employee fails to book the same day again
	And the employee logs out

@TimeOff Appointment @CancellingAppointment
Scenario: Cancelling booked Appointment
	Given an employee logs into My Working Life
	When the employee goes to the Appointment request screen
	Then cancels the booked Appointment
	And the employee logs out