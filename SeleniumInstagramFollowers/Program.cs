using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumInstagramFollowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Siteye Gidildi.");
            Thread.Sleep(2000);
            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));


            IWebElement loginBtn = driver.FindElement(By.CssSelector("body._a3wf._-kb.segoe:nth-child(2) div.x9f619.x1n2onr6.x1ja2u2z:nth-child(1) div.x78zum5.xdt5ytf.x1n2onr6.x1ja2u2z div.x78zum5.xdt5ytf.x1n2onr6 div.x78zum5.xdt5ytf.x1n2onr6.xat3117.xxzkxad div.x78zum5.xdt5ytf.x10cihs4.x1t2pt76.x1n2onr6.x1ja2u2z:nth-child(1) section.x78zum5.xdt5ytf.x1iyjqo2.xg6iff7.x6ikm8r.x10wlt62:nth-child(1) main._a993._a994 article.x1qjc9v5.x6umtig.x1b1mbwd.xaqea5y.xav7gou.x9f619.x78zum5.x1q0g3np.x1iyjqo2.x2lah0s.xk390pu.xl56j7k.xg87l8a.xkrivgy.xat24cr.x1gryazu.x1ykew4q.xexx8yu.x4uap5.x1gan7if.xkhd6sd.x11njtxf.xh8yej3.x1d2lwc3 div._ab1y div._ab21:nth-child(1) div._ab3a form._ab3b div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.xqui205.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1 > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1xmf6yo.x1e56ztr.x540dpk.x1m39q7l.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1:nth-child(3)"));



            bilgiler bilgi = new bilgiler();
            userName.SendKeys(bilgi.kullaniciAdi());
            password.SendKeys(bilgi.sifre());
            loginBtn.Click();
            Console.WriteLine("Hesap Bilgileri Girildi");
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl($"https://www.instagram.com/{bilgi.kullaniciAdi()}/followers/");
            Console.WriteLine("Profile Yönlendirildi.");
            Thread.Sleep(2500);

            //ScrollDown Start
            string jsCommand = "" +
                "sayfa =document.querySelector('._aano');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfaSonu= sayfa.scrollHeight;" +
                "return sayfaSonu;";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(1200);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                {
                    break;
                }
            }


            //takipçi listeleme start
            int sayac = 1;
            IReadOnlyCollection<IWebElement> followers = driver.FindElements(By.CssSelector(".x1lliihq.x193iq5w.x6ikm8r.x10wlt62.xlyipyv.xuxw1ft"));
            foreach (IWebElement follower in followers)
            {
                Console.WriteLine(sayac + " ==> " + follower.Text);
                sayac++;
            }

            //takipçi listeleme end

        }
    }
}
