using System;
using Terminal.Gui;


namespace songWeedFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            // Window
            var win = new Window("Songs Weed Friends") {
                X = 0,
                Y = 1,

                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            // Menu Bar
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_App", new MenuItem [] {
                    new MenuItem ("_New", "Creates new Lobby", null),
                    new MenuItem ("_Quit", "", () => { if (Quit()) top.Running = false; })
                }),
		    });

            // Adding menu and window to top
            top.Add(menu);
            top.Add(win);

            // Login
            var login = new Label("Login: ") { X = 3, Y = 2 };

            // Password
            var password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 2
            };

            // Login
            var loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 40
            };

            // Password
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            // Cancel Button
            var cancel_button = new Button(3, 9, "Cancel");
            cancel_button.Clicked += () => {
                if(Quit()) {
                    top.Running = false;
                }
            };

            // Login Button
            var login_button = new Button(13, 9, "Login");
            
            // Remember Me Button
            var rme_button = new CheckBox(3, 6, "Remember Me");

            // Windows Add
            win.Add(
                login, 
                password, 
                loginText, 
                passText, 
                cancel_button,
                login_button,
                rme_button
                
            );

            Application.Run();
        }

        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Exit", "Are you sure you wanna exit Songs Weed Friends?", "Yes", "No");
            return n == 0;
        }
    }
}
