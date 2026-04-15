using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LinDesk_Linux_Desktop_Environment_Simulator.TerminalLogic;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Prefix ="demo@LinDesk:~$";
        private int inputStart;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            terminal = new TerminalController(TerminalBox);
            terminal.Start();
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // nastartuje boot seqvenciu nasho oska.
            // "await" znamena ze program caka dokim sa dokonci metoda StartBootSequence
            //await StartBootSequence();
        }
        private async Task StartBootSequence()
        {
            //async funguje tak ze mozem tuto metodu bez blokovania vykreslovacieho thredu vykonat operacie bez toho aby som musel cakat na dokoncenie vsetkych operacii,
            //co je idealne pre simulaciu bootovania, kde chcem zobrazovat postupne text bez toho aby sa aplikacia zasekla
            BootOutput.Clear();
            UsernameBox.Clear();
            PasswordBox.Clear();
            Terminal.Visibility = Visibility.Collapsed;
            PowerOptions.Visibility = Visibility.Collapsed;
            DesktopScreen.Visibility = Visibility.Collapsed; // skryje hlavny desktop
            BootScreen.Visibility = Visibility.Visible; // zobrazy bootovaci panel
            await Task.Delay(1000); //simulate initial delay
            {
                List<string> bootLines = new List<string>()
            {
"LinDesk Live Environment 1.0",
"",
"[ OK ] LinDesk Live Environment 1.0",
"Booting LinDesk kernel...",
"[ OK ] Initializing system services...",
"[ OK ] Checking hardware configuration...",
"[ OK ] Detecting CPU cores...",
"[ OK ] Loading kernel modules...",
"[ OK ] Initializing memory management...",
"[ OK ] Starting device manager...",
"[ OK ] Detecting storage devices...",
"[ OK ] Scanning /dev for devices...",
"[ OK ] Loading virtual filesystem...",
"[ OK ] Mounting root filesystem...",
"[ Failed ] Mounting /proc...",
"[ Failed ] Mounting /sys...",
"[ Failed ] Mounting /tmp...",
"[ WARN ] Filesystem check recommended on next boot",
"[ OK ] Initializing network stack...",
"[ OK ] Starting udev device manager...",
"[ OK ] Detecting USB controllers...",
"[ OK ] Detecting USB devices...",
"usb 1-1: new high-speed USB device detected",
"[ OK ] Initializing input devices...",
"[ OK ] Detecting keyboard...",
"[ OK ] Detecting mouse...",
"[ OK ] Loading graphics driver...",
"[ OK ] Initializing display subsystem...",
"[ Check ] Loading absolutely unnecessary modules...",
"[ OK ] Starting display server...",
"[ OK ] Initializing framebuffer...",
"[ OK ] Loading font subsystem...",
"[ OK ] Starting system logging service...",
"[ OK ] Starting scheduler...",
"[ OK ] Initializing user session manager...",
"[ OK ] Preparing runtime environment...",
"[ OK ] Starting process manager...",
"[ OK ] Loading environment variables...",
"[ OK ] Detecting network interfaces...",
"Interface eth0 detected",
"Interface wlan0 detected",
"[ OK ] Starting network manager...",
"[ WARN ] DHCP request delayed",
"[ OK ] Acquiring DHCP lease...",
"[ OK ] Network interface ready",
"[ OK ] Checking system clock...",
"[ OK ] Synchronizing system time...",
"[ OK ] Loading locale configuration...",
"[ OK ] Applying system policies...",
"[ OK ] Initializing power management...",
"[ OK ] Loading ACPI tables...",
"[ OK ] Detecting battery status...",
"[ OK ] Battery subsystem initialized",
"[ OK ] Initializing sound subsystem...",
"[ OK ] Detecting audio devices...",
"[ OK ] Audio driver loaded",
"[ OK ] Compiling excuses for slow startup...",
"[ OK ] Preparing user environment...",
"[ OK ] Mounting /home directory...",
"[ OK ] Mounting temporary storage...",
"[ OK ] Checking disk usage...",
"[ OK ] Loading system utilities...",
"[ OK ] Preparing command shell...",
"[ OK ] Initializing terminal services...",
"[ OK ] Starting security manager...",
"[ OK ] Applying access control rules...",
"[ OK ] Checking system permissions...",
"[ OK ] Loading authentication service...",
"[ OK ] Initializing login manager...",
"[ OK ] Preparing desktop environment...",
"[ OK ] Loading window manager...",
"[ OK ] Starting compositor...",
"[ OK ] Initializing graphical session...",
"[ OK ] Loading UI components...",
"[ OK ] Preparing application launcher...",
"[ OK ] Starting notification service...",
"[ OK ] Initializing task scheduler...",
"[ OK ] Preparing system monitor...",
"[ OK ] Loading package database...",
"[ OK ] Checking installed packages...",
"[ WARN ] Some optional packages missing",
"[ OK ] Initializing update service...",
"[ OK ] Scanning system paths...",
"[ OK ] Loading system icons...",
"[ OK ] Initializing font cache...",
"[ OK ] Loading theme engine...",
"[ OK ] Preparing desktop panel...",
"[ OK ] Loading user preferences...",
"[ OK ] Applying desktop configuration...",
"[ OK ] Preparing workspace manager...",
"[ OK ] Initializing clipboard service...",
"[ OK ] Loading background services...",
"[ OK ] Detecting removable media...",
"[ OK ] Checking USB storage devices...",
"[ OK ] Initializing device hotplug support...",
"[ OK ] Loading kernel extensions...",
"[ OK ] Preparing system shell...",
"[ OK ] Starting shell services...",
"[ OK ] Preparing user login session...",
"[ OK ] Loading terminal emulator...",
"[ OK ] Preparing window manager...",
"[ OK ] Initializing session services...",
"[ OK ] Starting background daemons...",
"[ OK ] Loading system hooks...",
"[ OK ] Preparing system API...",
"[ OK ] Starting IPC services...",
"[ OK ] Initializing system bus...",
"[ OK ] Starting DBus services...",
"[ OK ] Checking system integrity...",
"[ OK ] Loading kernel watchdog...",
"[ OK ] Initializing resource manager...",
"[ OK ] Loading system libraries...",
"[ OK ] Starting service watchdog...",
"[ OK ] Registering system signals...",
"[ OK ] Checking system temperature sensors...",
"[ OK ] Initializing thermal management...",
"[ OK ] Preparing runtime scheduler...",
"[ OK ] Initializing CPU frequency scaling...",
"[ OK ] Starting device polling services...",
"[ OK ] Preparing filesystem cache...",
"[ OK ] Initializing disk I/O scheduler...",
"[ OK ] Loading boot configuration...",
"[ OK ] Checking boot flags...",
"[ OK ] Preparing runtime modules...",
"[ OK ] Starting system diagnostics...",
"[ WARN ] Optional module 'lindesk-legacy-support' not found",
"[ OK ] Performing final system checks...",
"[ OK ] System initialization nearly complete...",
"[ OK ] Starting user services...",
"[ OK ] Preparing login prompt...",
"Linux Desktop Enviroment Simulator boot complete."
            };
                Random r = new Random();
                foreach (string line in bootLines)
                {

                    BootOutput.AppendText(line + Environment.NewLine); // pridá text na koniec a skočí na nový riadok podľa typu systému
                    BootOutput.ScrollToEnd(); // automaticky odroluje na koniec, aby bol vždy vidieť najnovší text
                    int wait = r.Next(1, 300); // random time in milliseconds
                    await Task.Delay(wait);
                }

                await Task.Delay(3000);
                BootScreen.Visibility = Visibility.Collapsed; // skryje bootovací panel po dokončení simulace
                LoginScreen.Visibility = Visibility.Visible; // zobrazí přihlašovací obrazovku

            }

        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false;
            LoginStatus.Text = string.Empty;
            string user = UsernameBox.Text?.Trim() ?? string.Empty;
            string pass = PasswordBox.Password ?? string.Empty;

            // simulate authentication delay
            await Task.Delay(600);

            if (user == "demo" && pass == "demo")
            {
                // successful login
                LoginScreen.Visibility = Visibility.Collapsed; // hide login
                DesktopScreen.Visibility = Visibility.Visible; // show desktop
            }
            else
            {
                LoginStatus.Text = "Invalid username or password. Please try again.";
            }

            LoginButton.IsEnabled = true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // simple reset behavior: clear fields
            UsernameBox.Clear();
            PasswordBox.Clear();
            PasswordVisibleBox.Text = string.Empty;
            LoginStatus.Text = "Password reset not implemented.";
        }

        private void PwdReveal_Checked(object sender, RoutedEventArgs e)
        {
            // show plain-text password
            PasswordVisibleBox.Text = PasswordBox.Password;
            PasswordVisibleBox.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;
        }

        private void PwdReveal_Unchecked(object sender, RoutedEventArgs e)
        {
            // hide plain-text password
            PasswordBox.Password = PasswordVisibleBox.Text;
            PasswordVisibleBox.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // keep visible textbox in sync when reveal is active
            if (PasswordVisibleBox.Visibility == Visibility.Visible)
            {
                PasswordVisibleBox.Text = PasswordBox.Password;
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PowerOptions.Visibility == Visibility.Collapsed)
            {
                PowerOptions.Visibility = Visibility.Visible;
            }
            else
            {
                PowerOptions.Visibility = Visibility.Collapsed;
            }
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(1000); //simulate shutdown delay
            Process.GetCurrentProcess().Kill();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(1000); //simulate restart delay
            StartBootSequence();
        }

        private void Sleep_Click(object sender, RoutedEventArgs e)

        {
            Thread.Sleep(1000); //simulate sleep delay
            DesktopScreen.Visibility = Visibility.Collapsed; // schova hlavny desktop
            SleepMode.Visibility = Visibility.Visible; // zobrazy obrazovku sleep
        }
        private void SleepScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Thread.Sleep(1000); //simulate wake up delay
            SleepMode.Visibility = Visibility.Collapsed; // schova obrazovku sleep
            DesktopScreen.Visibility = Visibility.Visible; // zobrazy hlavny desktop
        }

        private void TerminalButton_Click(object sender, RoutedEventArgs e)
        {
            if (Terminal.Visibility == Visibility.Collapsed)
                Terminal.Visibility = Visibility.Visible;
            else
                Terminal.Visibility = Visibility.Collapsed;
        }
        private TerminalController terminal;


        private void TerminalBox_KeyDown(object sender, KeyEventArgs e)
        {
            terminal.HandleKeyDown(e);
        }

        private void TerminalBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            terminal.HandlePreviewKeyDown(e);
        }

        private void TerminalBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            terminal.HandlePreviewMouseDown(e);
        }

        private void TerminalBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            terminal.HandleSelectionChanged();
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
