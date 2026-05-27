using LinDesk_Linux_Desktop_Environment_Simulator;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public partial class MainWindow : Window
    {
        public string MainPrefix = "demo@LinDesk:~$";
        public string justaspace = " ";
        public string executedLine;
        public FileConstructor CurrentFile;
        public DirectoryConstructor CurrentDirectory;
        public DirectoryHandler directoryHandler = new DirectoryHandler();
        public MusicHandler musicHandler;
        public List<SongConstructor> songs;
        public int currentIndex = 0;
        public MediaPlayer mediaPlayer = new MediaPlayer();
        public bool isPlaying = false;
        public UsagePanel usagePanel = new UsagePanel();
        public CalculatorLogic calculator = new CalculatorLogic();
        // timer for media player updates
        private DispatcherTimer timer;
        // track last visited directory for FE back button
        private DirectoryConstructor LastDirectory;

        public MainWindow()
        {
            InitializeComponent();
            CurrentDate.Content = DateTime.Now.ToString("dddd, dd.MM.yyyy", new System.Globalization.CultureInfo("en-US"));

            Loaded += MainWindow_Loaded;

            CurrentDirectory = directoryHandler.Root;

            musicHandler = new MusicHandler();
            songs = new List<SongConstructor>(musicHandler.Songs);
            if (songs.Count > 0)
            {
                currentIndex = 0;
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            Loaded += MainWindow_Loaded;

            CurrentDirectory = directoryHandler.Root;

            musicHandler = new MusicHandler();
            songs = new List<SongConstructor>(musicHandler.Songs);
            if (songs.Count > 0)
            {
                currentIndex = 0;
            }
            if (songs.Count > 0)
            {
                SongName.Content = System.IO.Path.GetFileNameWithoutExtension(songs[currentIndex].FilePath);
                ArtistName.Content = songs[currentIndex].Artist;
            }



            TerminalHistory.AppendText("Welcome to LinDesk 1.0 (Simulated Environment)\r\n\r\nSystem information as of session start:\r\n\r  System load: 0.03\n  Processes: 112 running\n  Memory usage: 842MB / 4096MB\n  Disk usage: 12% of 120GB\n  Network: connected\r\n\r\nNo updates available.\r\n\r\nDocumentation: https://lindesk.local/docs\r\nSupport: https://lindesk.local/support\r\n\r\nTip: Type 'help' to see available commands.\r\nTip: Command history (↑/↓) is not supported in this demo.\r\n\r\ndemo@lindesk:~$\r\n");
            MainPrefix = MainPrefix + justaspace;

            // init single-line prompt and hook events
            TerminalBox.Document.Blocks.Clear();
            TerminalBox.Document.Blocks.Add(new Paragraph(new Run(MainPrefix)));
            TerminalBox.CaretPosition = TerminalBox.Document.ContentEnd;
            TerminalBox.Focus();

            TerminalBox.PreviewKeyDown += TerminalBox_PreviewKeyDown;
            TerminalBox.TextChanged += TerminalBox_TextChangedHandler;
            //_ = UpdateLabel(); // start background task to update directory label
            usagePanel.Usage(CpuUsage, RamUsage, DiskUsage, NetUsage, LoadAvg, WorldTime, UpTime);
            _ = usagePanel.Usage(CpuUsage, RamUsage, DiskUsage, NetUsage, LoadAvg, WorldTime, UpTime);

            // Bind the FE items control to the current directory's files collection
            FEItemsControl.ItemsSource = CurrentDirectory.Files;
            // Listen for collection changes on the files collection to ensure UI updates when files are created
            // (ObservableCollection will notify automatically; this assignment is sufficient)
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Start boot sequence asynchronously and await it to avoid CS1998 warning.
            //await StartBootSequence();
        }

        private async Task StartBootSequence()
        {
            //async funguje tak ze mozem tuto metodu bez blokovania vykreslovacieho thredu vykonat operacie bez toho aby som musel cakat na dokoncenie vsetkych operacii,
            //co je idealne pre simulaciu bootovania, kde chcem zobrazovat postupne text bez toho aby sa aplikacia zasekla
            TerminalBox.Document.Blocks.Clear(); // vyčistí obsah terminálu
            TerminalBox.Document.Blocks.Add(new Paragraph(new Run(MainPrefix))); // přidá nový řádek s promptem
            BootOutput.Clear();
            UsernameBox.Clear();
            pass.Clear();
            Terminal.Visibility = Visibility.Collapsed;
            PowerOptions.Visibility = Visibility.Collapsed;
            DesktopScreen.Visibility = Visibility.Collapsed; // skryje hlavni desktop
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
                BootScreen.Visibility = Visibility.Collapsed;
                LoginScreen.Visibility = Visibility.Visible;

            }

        }
        //LOGIN button handler checks if the username and password are correct demo/demo and if so, simulates a short delay before showing the desktop screen. If the credentials are incorrect, it updates the login status text to inform the user.
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsernameBox.Text == "demo" && pass.Password == "demo")
            {
                Thread.Sleep(3000);
                LoginScreen.Visibility = Visibility.Collapsed;
                DesktopScreen.Visibility = Visibility.Visible;
            }
            else
            {
                LoginStatus.Text = "Invalid username or password. Please try again.";
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PowerOptions.Visibility == Visibility.Collapsed)
            {
                PowerOptions.Visibility = Visibility.Visible;
                FadeIn(PowerOptions);
            }
            else
            {
                PowerOptions.Visibility = Visibility.Collapsed;
                FadeOut(PowerOptions);
            }
        }

        private async void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000); //simulate shutdown delay
            Process.GetCurrentProcess().Kill();
        }

        private async void Restart_Click(object sender, RoutedEventArgs e)
        {
            // make non-blocking delay then await boot sequence to avoid CS4014
            await Task.Delay(1000); //simulate restart delay
            await StartBootSequence();
        }

        private async void Sleep_Click(object sender, RoutedEventArgs e)

        {
            await Task.Delay(1000); //simulate sleep delay
            DesktopScreen.Visibility = Visibility.Collapsed; // schova hlavny desktop
            SleepMode.Visibility = Visibility.Visible; // zobrazy obrazovku sleep
            SleepVideo.Play();
        }
        private async void SleepScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(1000); //simulate wake up delay
            SleepMode.Visibility = Visibility.Collapsed; // schova obrazovku sleep
            DesktopScreen.Visibility = Visibility.Visible; // zobrazy hlavni desktop
            SleepVideo.Stop();
        }

        private void TerminalButton_Click(object sender, RoutedEventArgs e)
        {
            if (Terminal.Visibility == Visibility.Collapsed)
            {
                Terminal.Visibility = Visibility.Visible;
                FadeIn(Terminal);
            }
            else
            {
                Terminal.Visibility = Visibility.Collapsed;
                FadeOut(Terminal);
            }
        }
        private void MusicPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (MP.Visibility == Visibility.Collapsed)
            {
                MP.Visibility = Visibility.Visible;
                FadeIn(MP);
            }
            else
            {
                MP.Visibility = Visibility.Collapsed;
                FadeOut(MP);
            }
        }
        private void NanoEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System)
            {
                CurrentFile.Content = NanoContent.Text;
                NanoEditor.Visibility = Visibility.Collapsed;
                NewFileWarning.Visibility = Visibility.Collapsed;
                Terminal.Visibility = Visibility.Visible;
            }
        }

        private void TerminalBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // ai made this code to prevent user from deleting the prompt prefix, not manually written by me
            var caret = TerminalBox.CaretPosition;
            // compute absolute indexes (strip CR)
            int caretIndex = new TextRange(TerminalBox.Document.ContentStart, caret).Text.Replace("\r", "").Length;
            var selection = TerminalBox.Selection;
            int selectionStart = new TextRange(TerminalBox.Document.ContentStart, selection.Start).Text.Replace("\r", "").Length;
            int selectionEnd = new TextRange(TerminalBox.Document.ContentStart, selection.End).Text.Replace("\r", "").Length;

            // compute full cleaned text and last prompt index
            string fullCleaned = new TextRange(TerminalBox.Document.ContentStart, TerminalBox.Document.ContentEnd).Text.Replace("\r", "");
            int lastPromptIdx = fullCleaned.LastIndexOf(MainPrefix);
            if (lastPromptIdx < 0) lastPromptIdx = 0;

            // compute positions relative to last prompt
            int relativeCaret = caretIndex - lastPromptIdx;
            int relativeSelectionStart = selectionStart - lastPromptIdx;
            int relativeSelectionEnd = selectionEnd - lastPromptIdx;

            // prevent Backspace/Delete when caret or selection would affect the current prompt prefix
            if (e.Key == Key.Back)
            {
                if (relativeCaret <= MainPrefix.Length || relativeSelectionStart < MainPrefix.Length)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.Key == Key.Delete)
            {
                if (relativeCaret < MainPrefix.Length || relativeSelectionStart < MainPrefix.Length)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                var fullTextRange = new TextRange(TerminalBox.Document.ContentStart, TerminalBox.Document.ContentEnd);
                string full = fullTextRange.Text ?? "";

                // Normalize: remove CR chars
                string cleaned = full.Replace("\r", "");

                // FlowDocument often has a trailing newline; remove one trailing '\n' if present
                if (cleaned.EndsWith("\n"))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 1);
                }

                int idx = cleaned.LastIndexOf(MainPrefix);

                if (idx >= 0)
                {
                    executedLine = cleaned.Substring(idx);
                }
                else
                {
                    executedLine = MainPrefix;
                }

                if (TerminalHistory != null)
                {
                    TerminalHistory.AppendText(executedLine + Environment.NewLine);
                    try
                    {
                        TerminalHistory.ScrollToEnd();
                    }
                    catch
                    {

                    }
                }

                if (!MainPrefix.EndsWith(" "))
                {
                    MainPrefix += " ";
                }

                TerminalHandler.TerminalExecute(TerminalBox, TerminalHistory, new string[] { executedLine }, executedLine, PrefixLabel, CommandLabel, DirectoryLabel, DirectoryLabel, ref CurrentDirectory, ref MainPrefix, NanoEditor, FileName, NanoContent, ref CurrentFile, NewFileWarning, Terminal, SleepMode, SleepVideo, Calculator, SettingsMenu, MusicPlayer);
                // Ensure FE shows files from the (possibly updated) current directory
                if (FEItemsControl != null)
                {
                    FEItemsControl.ItemsSource = CurrentDirectory.Files;
                }
                TerminalBox.Document.Blocks.Add(new Paragraph(new Run(MainPrefix)));
                TerminalBox.CaretPosition = TerminalBox.Document.ContentEnd;
                TerminalBox.Focus();
                DebugLabel.Content = $"Executed: '{executedLine}'";
            }
        }
        private void TerminalBox_TextChangedHandler(object sender, TextChangedEventArgs e)
        {
            // ai made this code to restore the prompt prefix if user tries to delete it, not manually written by me
            // get last paragraph text (preserves previous prompt lines)
            var lastBlock = TerminalBox.Document.Blocks.LastBlock as Paragraph;
            string lastText = lastBlock != null
            ? new TextRange(lastBlock.ContentStart, lastBlock.ContentEnd).Text.Replace("\r", "").Replace("\n", "") :
            "";

            // if the current editing line lost the prefix, restore it while preserving typed tail
            if (!lastText.StartsWith(MainPrefix))
            {

                string tail = lastText;
                int idx = tail.IndexOf(MainPrefix);
                if (idx >= 0) tail = tail.Substring(idx + MainPrefix.Length);

                // replace only the last block so previous prompts remain intact
                if (lastBlock != null)
                    TerminalBox.Document.Blocks.Remove(lastBlock);
                TerminalBox.Document.Blocks.Add(new Paragraph(new Run(MainPrefix + tail)));
                TerminalBox.CaretPosition = TerminalBox.Document.ContentEnd;
            }
            else
            {
                TerminalBox.CaretPosition = TerminalBox.Document.ContentEnd;
            }

        }
        private async Task UpdateLabel()
        {
            while (true)
            {
                await Task.Delay(1000);
                DirectoryLabel.Content = $"Current Directory: {CurrentDirectory.DirectoryName}";
            }
        }
        private void FadeIn(UIElement element)
        {
            // ai generated code for fade in animation, not manually written by me
            element.Visibility = Visibility.Visible;

            DoubleAnimation fade = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200));
            element.BeginAnimation(UIElement.OpacityProperty, fade);

            ScaleTransform scale = (ScaleTransform)((FrameworkElement)element).RenderTransform;

            DoubleAnimation scaleUp = new DoubleAnimation(0.95, 1, TimeSpan.FromMilliseconds(200));
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUp);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUp);
        }
        private void FadeOut(UIElement element)
        {
            // ai generated code for fade out animation, not manually written by me
            DoubleAnimation fade = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));

            fade.Completed += (s, e) =>
            {
                element.Visibility = Visibility.Collapsed;
            };

            element.BeginAnimation(UIElement.OpacityProperty, fade);

            ScaleTransform scale = (ScaleTransform)((FrameworkElement)element).RenderTransform;

            DoubleAnimation scaleDown = new DoubleAnimation(1, 0.95, TimeSpan.FromMilliseconds(200));
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDown);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDown);
        }
        
        private void CalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            //Tries to treat whatever triggered the event as a Button object
            Button button = sender as Button;
            string Pressed = button.Content.ToString();
            if (calculator.Clear == true)
            {
                CalcOutput.Text = "";
                calculator.Clear = false;
            }
            calculator.Press(Pressed);
            if (Pressed == "+" || Pressed == "-" || Pressed == "*" || Pressed == "/")
            {
                CalcOutput.Text = CalcOutput.Text + " " + Pressed + " ";
                calculator.Operator = true;
            }
            else if (Pressed == "=")
            {
                calculator.Equals = true;
            }
            else
            {
                CalcOutput.Text = CalcOutput.Text + Pressed;
            }
            calculator.Calculator(CalcOutput);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Calculator.Visibility = Visibility.Collapsed;
            CalcOutput.Text = "";
        }

        private void SExit_Click(object sender, RoutedEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Collapsed;
        }

        private void ResourceToggle_Checked(object sender, RoutedEventArgs e)
        {
            UsageInfo.Visibility = Visibility.Visible;
        }

        private void ResourceToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            UsageInfo.Visibility = Visibility.Collapsed;
        }

        private void UpTimeCounter_Checked(object sender, RoutedEventArgs e)
        {
            UpTime.Visibility = Visibility.Visible;
        }

        private void UpTimeCounter_Unchecked(object sender, RoutedEventArgs e)
        {
            UpTime.Visibility = Visibility.Collapsed;
        }

        private void FEExit_Click(object sender, RoutedEventArgs e)
        {
            FE.Visibility = Visibility.Collapsed;
        }

        // Handler for file buttons inside the File Explorer ItemsControl
        private void FEFileButton_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            if (btn == null) return;

            string fileName = btn.Content?.ToString() ?? "";
            FileConstructor file = CurrentDirectory.Files.FirstOrDefault(f => f.Name == fileName);
            if (file != null)
            {
                CurrentFile = file;
                FileName.Content = file.Name;
                NanoContent.Text = file.Content;
                Terminal.Visibility = Visibility.Collapsed;
                NanoEditor.Visibility = Visibility.Visible;
                NewFileWarning.Visibility = Visibility.Collapsed;
            }
        }
        
        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            var currentSong = songs[currentIndex];
            if (!string.IsNullOrEmpty(currentSong.FilePath))
            {
                mediaPlayer.Open(new Uri(currentSong.FilePath));
            }
            // update UI mEDIAdata
            SongName.Content = System.IO.Path.GetFileNameWithoutExtension(currentSong.FilePath);
            ArtistName.Content = currentSong.Artist;
            if (isPlaying == true)
            {
                mediaPlayer.Pause();
                isPlaying = false;
                PlayPause.Content = "Play";
                timer.Stop();
            }
            else
            {
                mediaPlayer.Play();
                isPlaying = true;

                PlayPause.Content = "Pause";
                timer.Start();
            }

        }

        private void Rewind_Click(object sender, RoutedEventArgs e)
        {
            // If more than 10 seconds into the song restart same song
            if (mediaPlayer.Position.TotalSeconds > 10)
            {
                mediaPlayer.Position = TimeSpan.Zero;
                //mediAdata 
                SongName.Content = System.IO.Path.GetFileNameWithoutExtension(songs[currentIndex].FilePath);
                ArtistName.Content = songs[currentIndex].Artist;
                if (!isPlaying)
                {
                    mediaPlayer.Play();
                    isPlaying = true;
                    PlayPause.Content = "Pause";
                    timer.Start();
                }
            }
            else
            {
                // otherwise go to previous song wrap around
                if (songs.Count == 0) return;
                currentIndex = (currentIndex - 1 + songs.Count) % songs.Count;
                var currentSong = songs[currentIndex];
                mediaPlayer.Open(new Uri(currentSong.FilePath));
                mediaPlayer.Position = TimeSpan.Zero;
                mediaPlayer.Play();
                isPlaying = true;
                PlayPause.Content = "Pause";
                SongName.Content = System.IO.Path.GetFileNameWithoutExtension(currentSong.FilePath);
                ArtistName.Content = currentSong.Artist;
                timer.Start();
            }
        }
        //otherwise go to next song wrap around
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (songs.Count == 0) return;
            currentIndex = (currentIndex + 1) % songs.Count;
            var currentSong = songs[currentIndex];
            mediaPlayer.Open(new Uri(currentSong.FilePath));
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
            isPlaying = true;
            PlayPause.Content = "Pause";
            SongName.Content = System.IO.Path.GetFileNameWithoutExtension(currentSong.FilePath);
            ArtistName.Content = currentSong.Artist;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                Time.Content = $"{mediaPlayer.Position:mm\\:ss}/{mediaPlayer.NaturalDuration.TimeSpan:mm\\:ss}";
                MusicSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                MusicSlider.Value = mediaPlayer.Position.TotalSeconds;
            }
        }

        // handler for the MusicSlider 
        private void MusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {

                    var seconds = e.NewValue;
                    var newPos = TimeSpan.FromSeconds(seconds);
                    if (Math.Abs((mediaPlayer.Position - newPos).TotalSeconds) > 0.5)
                    {
                        mediaPlayer.Position = newPos;
                    }
                }
            }
            catch
            {

            }
        }
       
      



        //file manager buttons front and back 


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (LastDirectory != null)
            {
                CurrentDirectory = LastDirectory;
            }
            else if (CurrentDirectory.ParentDirectory == null)
            {

            }
            //song player 
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            Loaded += MainWindow_Loaded;

            CurrentDirectory = directoryHandler.Root;

            musicHandler = new MusicHandler();
            songs = new List<SongConstructor>(musicHandler.Songs);
            if (songs.Count > 0)
            {
                currentIndex = 0;
            }
            if (songs.Count > 0)
            {
                SongName.Content = System.IO.Path.GetFileNameWithoutExtension(songs[currentIndex].FilePath);
                ArtistName.Content = songs[currentIndex].Artist;
            }



        }


    }
}
