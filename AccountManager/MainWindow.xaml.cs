using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SavingAccount s = new SavingAccount();
        ChequingAccount c = new ChequingAccount();

        private void SavingRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void CheqRadio_Checked(object sender, RoutedEventArgs e)
        { }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //Saving Account
            if (SavingRadio.IsChecked == true)
            {
                //Withdraw
                if (WithdrawRadio.IsChecked == true)
                {
                    s.Withdraw(Convert.ToDouble(AmountTB.Text));
                }
                //Deposit
                if (DepositRadio.IsChecked == true)
                {
                    s.Deposit(Convert.ToDouble(AmountTB.Text));
                }

                BalanceTB.Text = Convert.ToString(s.Balance);
            }

            //Chequing Account
            if (CheqRadio.IsChecked == true)
            {
                //Withdraw
                if (WithdrawRadio.IsChecked == true)
                {
                    c.Withdraw(Convert.ToDouble(AmountTB.Text));
                }
                //Deposit
                if (DepositRadio.IsChecked == true)
                {
                    c.Deposit(Convert.ToDouble(AmountTB.Text));
                }

                BalanceTB.Text = Convert.ToString(c.Balance);
            }
        }

        private void WithdrawRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void DepositRadio_Checked(object sender, RoutedEventArgs e)
        { }
    }
}
public class SavingAccount
{
    public double Balance { get; set; }
    public void Withdraw(double amount)
    {
        Balance -= amount;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
    }
}
public class ChequingAccount
{
    public double Balance { get; set; }
    public void Withdraw(double amount)
    {
        Balance -= amount;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
    }
}