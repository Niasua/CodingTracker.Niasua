# ⏱️ Coding Tracker

A C# console application to help you track, view, and analyze your coding sessions, set coding goals, and monitor your progress.

## 📌 Main Features

- 🗃️ **Add, view, update, and delete coding sessions**
- ⏱️ **Track sessions using a stopwatch**
- 🔍 **Filter sessions by custom date range and sort them (ASC/DESC)**
- 📊 **Generate summary reports (Total and Average by day, week, month, or year)**
- 🎯 **Set coding goals and track your progress**
- 🧮 **See how many hours/day you need to code to reach your goal**
- 🧪 **Seed database with sample data for quick testing**
- 💾 **SQLite database integration using Dapper**

---

## 🛠️ Technologies Used

- C#
- .NET
- [Dapper](https://github.com/DapperLib/Dapper)
- SQLite
- [Spectre.Console](https://spectreconsole.net/) (for modern and friendly CLI UI)

---

## 📁 Project Structure

```bash
CodingTracker.Niasua/
├── Configuration/       # App configuration
├── Data/                # Database operations (CodingController) (DatabaseSeeder)
├── Models/              # Domain entities (CodingSession, CodingGoal, CodingSummary)
├── UI/                  # Table rendering using Spectre.Console
├── UserInput/           # Input validation and parsing
└── Program.cs           # Main menu and app logic
```

---

## 🧪 Seed Data

The `DatabaseSeeder` class automatically populates:

- 📌 **3 coding sessions** with realistic timestamps
- 🎯 **1 coding goal** (e.g., 20 hours within 7 days)

This allows users to immediately interact with the app and test all features without having to input data manually.

---

## 📋 Main Menu Options

Upon running the app, you can choose from:

- View all sessions
- Add new session
- Delete session
- Delete all sessions
- Update session
- Start stopwatch session
- Filter coding records per period
- Show summary report
- Set coding goal
- Show goal progress
- Exit

---

## 📈 Reports & Goals

You can generate summary reports grouped by:

- 🗓️ Daily
- 📅 Weekly
- 📆 Monthly
- 📖 Yearly

Additionally, you can:

- Set a coding goal (target hours + deadline)
- View your current progress
- Calculate how many hours per day you need to code to meet the goal

---

## 🧼 Deleting All Records
From the main menu, you can select Delete all sessions (with confirmation). This is useful for resetting the app without removing the database file.
