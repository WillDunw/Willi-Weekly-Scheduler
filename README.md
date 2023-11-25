# Schedule-Planner-WPF
A WPF scheduler app used to schedule events and view how you spend your time.
I made this on my own time to help myself organize my time and tasks during school and see where I wasted the most time.
I also wanted to pose myself the challenge of learning a new language in the form of Visual Basic .NET for this project.

## How to Install

### Prerequisites
Before installing, ensure you have the following installed:
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended version: [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/))
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)

### Installation Steps

1. **Clone the Repository:**

`git clone https://github.com/YourUsername/YourWPFApp.git`

2. **Open the Project in Visual Studio:**
- Open Visual Studio.
- Choose "Open a project or solution" and navigate to the directory where you cloned the repository.
- Select the `.sln` file and click "Open."

3. **Restore NuGet Packages:**
- Once the project is open, right-click on the solution in the Solution Explorer.
- Select "Restore NuGet Packages" to ensure all necessary packages are installed.

4. **Build and Run the Application:**
- Set the WPF project as the startup project.
- Click the "Start" button or press `F5` to build and run the application.

5. **Explore the App:**
- Once the application is running, explore the various features and functionalities.

## Main Features

Since I built this for my own personal use I tailored these features so they would be useful to me.

- Adding an event: you can schedule events individually and sort them based off of their category.
- Next week planner: there is capability to detect when the next monday is and to allow you to schedule all your tasks up until that day.
- Day view: you can view all your events for the day like a calendar and modify them however you need.
- Monthly view: this is a calendar view of all your events for the month. You can edits events and view specific days from this view.
- Weekly time breakdown: you can view your weekly distribution of time in the form of a pie chart to see where you spent the most time.

## Main Technologies

The app is built using WPF for the UI, Visual Basic as the programming language and SQLite as the database. The application was built using the MVP design pattern.
