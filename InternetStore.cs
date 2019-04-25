﻿using System;
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
        Register register;
        PasswordWriter passwordWriter;

        public void Run()
        {
            loginer = new Login();
            users = new List<User>();
            register = new Register();
            passwordWriter = new PasswordWriter();

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
                            passwordStr = passwordWriter.Write();
                            
                            if (loginer.Access(users, loginStr, passwordStr))
                            {
                                User user;
                                using(var context = new AppContext())
                                {
                                user = context.Users.Where(u => u.Login == loginStr).FirstOrDefault();
                                
                                Console.WriteLine($"Добро пожаловать!");
                                bool flag = true;

                                while (flag)
                                {
                                    switch (InnerMenu())
                                    {
                                        case 1:
                                            {
                                                if(products.Count > 0)
                                                {
                                                    for(int i = 0; i < products.Count; i++) 
                                                    {
                                                        Console.WriteLine($"{i + 1})");
                                                        products[i].Print();
                                                    }
                                                    Console.WriteLine("Введите индекс товара: ");
                                                    if(int.TryParse(Console.ReadLine(), out int buyIndex))
                                                    {
                                                        if(buyIndex > 0 && buyIndex <= products.Count)
                                                        {
                                                            user.Cart.Products.Add(new Product()
                                                            {
                                                                Cost = products[buyIndex - 1].Cost,
                                                                Name = products[buyIndex - 1].Name
                                                            });
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if(user.Cart.Products.Count > 0)
                                                {
                                                    foreach(var product in user.Cart.Products)
                                                    {
                                                        product.Print();
                                                    }  
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if(user.Cart.Products.Count > 0)
                                                {
                                                    double sum = 0;
                                                    foreach(var product in user.Cart.Products) 
                                                    {
                                                        sum+=product.Cost;
                                                        product.Print();
                                                    }
                                                    Console.WriteLine($"К оплате: {sum}");
                                                    user.Cart.Products.Clear();
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                flag = false;
                                                break;
                                            }
                                    }
                                }
                                context.SaveChanges();
                                }
                            }
                            else  
                                Console.WriteLine("Неверный логин пользователя или пароль!");
                            break;
                        }
                    case 2:
                        {
                            if(register.TryAddUser(users, out User user))
                            {
                                Console.WriteLine("Регистрация прошла успешно.");
                                user.Cart = new Cart();
                                users.Add(user);
                                using(var context = new AppContext())
                                {
                                    context.Users.Add(user);
                                    context.SaveChanges();
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Регистрация прервана!");
                            }
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
