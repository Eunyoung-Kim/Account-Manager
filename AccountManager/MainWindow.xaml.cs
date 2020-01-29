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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //Validate empty input
            if (AmountTB.Text == "")
            {
                MessageBox.Show("Please enter the amount for transaction", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Convert.ToDouble(AmountTB.Text) <= 0)
                {
                    MessageBox.Show("Please check the amount and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //Saving Account
                    if (SavingRadio.IsChecked == true)
                    {
                        //Withdraw
                        if (WithdrawRadio.IsChecked == true)
                        {
                            if (Convert.ToDouble(AmountTB.Text) > s.Balance)
                            {
                                MessageBox.Show("You can not withdraw the amount which exceed your balance", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                if (MessageBox.Show($"Do you want to withdraw ${AmountTB.Text} from your Saving account?", "Transaction Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    s.Withdraw(Convert.ToDouble(AmountTB.Text));
                                    BalanceTB.Text = Convert.ToString(s.Balance);
                                }
                            }
                        }

                        //Deposit
                        if (DepositRadio.IsChecked == true)
                        {
                            if (MessageBox.Show($"Do you want to deposit ${AmountTB.Text} to your Saving account?", "Transaction Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                s.Deposit(Convert.ToDouble(AmountTB.Text));
                                BalanceTB.Text = Convert.ToString(s.Balance);
                            }
                        }
                    }

                    //Chequing Account
                    if (CheqRadio.IsChecked == true)
                    {
                        //Withdraw
                        if (WithdrawRadio.IsChecked == true)
                        {
                            if (Convert.ToDouble(AmountTB.Text) > c.Balance)
                            {
                                MessageBox.Show("You can not withdraw the amount which exceed your balance", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                if (MessageBox.Show($"Do you want to withdraw ${AmountTB.Text} from your Chequing account?", "Transaction Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    c.Withdraw(Convert.ToDouble(AmountTB.Text));
                                    BalanceTB.Text = Convert.ToString(c.Balance);
                                }
                            }
                        }

                        //Deposit
                        if (DepositRadio.IsChecked == true)
                        {
                            if (MessageBox.Show($"Do you want to deposit ${AmountTB.Text} to your Chequing account?", "Transaction Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                c.Deposit(Convert.ToDouble(AmountTB.Text));
                                BalanceTB.Text = Convert.ToString(c.Balance);
                            }
                        }
                    }
                }
            }
        }
        private void SavingRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void CheqRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void WithdrawRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void DepositRadio_Checked(object sender, RoutedEventArgs e)
        { }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
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