## DReservation Project

.NET Core 2.1 based doctor appointment application.

### How to use?

- First clone repository in a folder.
- If not installed, install .NET Core 2.1 or a higher version
- Get in the folder like cd /home/root/application
- Type "dotnet restore"
- That's all.

### Application Project and Folder Structure

- DReservation Class Library
	- Common
	- Models
	- Providers
	- Services
	- Settings

- DReservation.UI (Web)
	- Controllers
	- Models
	- Views 
	 (Simple)
	
- DReservation.Test
	- Integration Test
	- UnitTests

### TESTS Libraries

 - "Moq" for mocking.
 - FluentAssertions for easy assertion.
 - NUnit for easy unit testing.