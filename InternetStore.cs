using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    public class InternetStore
    {
        const int MAIN_MENU_CNT = 3;
        const int INNER_MENU_CNT = 4;

        Login loginer;
        List<User> users;
        List<Product> products;
        Cart cart;

        public void Run()
        {
            loginer = new Login();
            users = new List<User>();
            
            using (var context = new AppContext())
            {
                users = context.Users.ToList();
                products = context.Products.ToList();
            }

            while (true)
            {
                switch (MainMenu())
                {
                    case 1:
                        {
                            string loginStr, passwordStr;

                            Console.WriteLine("Введите логин: ");
                            loginStr = Console.ReadLine();
                            Console.WriteLine("Введите пароль: ");
                            passwordStr = Console.ReadLine();

                            if (loginer.Access(users, loginStr, passwordStr))
                            {
                                User user = (User)from u in users
                                                  where u.Login.ToUpper().Equals(loginStr)
                                                  select u;
                                Console.WriteLine("Добро пожаловать!");
                                bool flag = true;

                                while (flag)
                                {
                                    switch (InnerMenu())
                                    {
                                        case 1:
                                            {
                                                foreach (var p in products)
                                                {
                                                    p.Print();
                                                }

                                                break;
                                            }
                                        case 2:
                                            {
                                                break;
                                            }
                                        case 3:
                                            {
                                                break;
                                            }
                                        case 4:
                                            {
                                                flag = false;
                                                break;
                                            }
                                    }
                                }
                                
                            }
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

            }
        }
        private int MainMenu()
        { 
            Console.WriteLine("Введите действие: ");
            Console.WriteLine("1) Вход");
            Console.WriteLine("2) Регистрация");
            Console.WriteLine("3) Выход из приложения");

            if(int.TryParse(Console.ReadLine(), out int menu))
            {
                if(menu > 0 && menu <= MAIN_MENU_CNT)
                {
                    return menu;
                }
            }
            return -1;
        }
        private int InnerMenu()
        {
            Console.WriteLine("\nВыберите действие: ");
            Console.WriteLine("1) Выбрать товары");
            Console.WriteLine("2) Посмотреть в корзину");
            Console.WriteLine("3) Перейти к оплате");
            Console.WriteLine("4) Выйти из аккаунта");

            if (int.TryParse(Console.ReadLine(), out int menu))
            {
                if (menu > 0 && menu <= INNER_MENU_CNT)
                {
                    return menu;
                }
            }
            return -1;
        }
    }
}
