using System.Threading.Tasks;
using System.Windows;

namespace AwaitClick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
{
public MainWindow()
{
    InitializeComponent();
    btnTest.WhenClicked().ContinueWith(k => { MessageBox.Show("Po klinieciu"); });
    StopAfterButton();

//działa tylko raz
btnNoClickEvent.WhenClicked( 
    () => 
    MessageBox.Show("Działa tylko raz"));
}

public async Task StopAfterButton()
{
    tb_wait.Text = "Nacisnij przycisk aby przejść dalej ";
    await btnTest.WhenClicked();
    tb_wait.Text = "Dzięki";
}

    private void btnTest_Click(object sender, RoutedEventArgs e)
    {
        btnTest.WhenClicked().ContinueWith(k => { MessageBox.Show("Po klinieciu"); });
        MessageBox.Show("W trakcie kliknięcia");
   
    }



}
}
