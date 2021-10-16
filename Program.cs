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
            bool login = true;

            // Window
            var win = new Window("Songs Weed Friends")
            {
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
            var login_username = new Label("Username: ") { X = 3, Y = 2 };

            // Password
            var login_password = new Label("Password: ")
            {
                X = Pos.Left(login_username),
                Y = Pos.Top(login_username) + 2
            };

            // Login
            var loginText = new TextField("")
            {
                X = Pos.Right(login_password),
                Y = Pos.Top(login_username),
                Width = 30
            };

            // Password
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(login_password),
                Width = Dim.Width(loginText)
            };

            // Register Page
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////
            var register_username = new Label("Username: ") { X = 3, Y = 2 };
            var register_password = new Label("Password: ") {
                X = Pos.Left(register_username),
                Y = Pos.Top(register_username) + 2
            };
            var reg_username_text = new TextField("") {
                X = Pos.Right(register_username),
                Y = Pos.Top(register_username),
                Width = 30
            };
            var reg_password_text = new TextField("") {
                Secret = true,
                X = Pos.Left(reg_username_text),
                Y = Pos.Top(register_username) + 2,
                Width = Dim.Width(reg_username_text)
            };
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////

            // Cancel Button
            var cancel_button = new Button(3, 9, "Cancel");
            cancel_button.Clicked += () =>
            {
                if (Quit())
                {
                    top.Running = false;
                }
            };

            // Login Button
            var login_button = new Button(13, 9, "Login");

            // Remember Me Button
            var rme_button = new CheckBox(3, 6, "Remember Me");

            // Register View Button
            var register_v_button = new Button(33, 5, "Register instead");
            register_v_button.Clicked += () =>
            {
                login = false;
                win.RemoveAll();
                win.Add(
                    register_username,
                    register_password,
                    reg_username_text,
                    reg_password_text,
                    cancel_button
                );
            };

            // Windows Add Login Page
            if(login) {
                win.Add(
                    login_username,
                    login_password,
                    loginText,
                    passText,
                    register_v_button,
                    cancel_button,
                    login_button,
                    rme_button
                );
            }

            Application.Run();
        }

        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Exit", "Are you sure you wanna exit Songs Weed Friends?", "Yes", "No");
            return n == 0;
        }
    }
}
