// Your Name: [Your Name]
// Team Name: ........
// Sprint Number: 01

// Date: 2024-10-18

// Version: 1.0

// Name of the program: Astronomical Processing

// Program Description:
// This program simulates astronomical data processing by generating a list of random neutrino interaction values. 
// Users can search for specific values using binary search, sort the data using bubble sort, and edit values directly in the displayed list.
// The program checks if the array is sorted before allowing binary search, and it highlights the found value in the list when found.

// Inputs: 
// - A user-specified value in the search box to find in the neutrinoData array.
// - Button clicks to trigger sorting and searching functionalities.
// - Double-clicking on the list to edit a specific neutrino interaction value.

// Processes:
// - Generating an array of random integers to simulate hourly neutrino interactions.
// - Sorting the array using the Bubble Sort algorithm.
// - Searching for a user-inputted value using Binary Search.
// - Editing an element of the array through a double-click interaction on the list box.

// Outputs:
// - Sorted array displayed in the list box.
// - Search result message showing if a value was found or not.
// - Highlighted value in the list box when the binary search finds the specified value.
// - User input box for editing a list item.
// - A message box displaying confirmation of the edit.

namespace Astronomical_Processing_
{
    public partial class Form1 : Form
    {
        int[] neutrinoData = new int[24]; // Array to hold 24 integer values representing hourly neutrino interactions

        public Form1()
        {
            InitializeComponent();
            // Attach double-click event for ListBox
            listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate array with random integers between 10 and 90
            Random random = new Random();
            for (int i = 0; i < neutrinoData.Length; i++)
            {
                neutrinoData[i] = random.Next(10, 91); // Generates random numbers between 10 and 90
            }
            DisplayArray(); // Display the array in the ListBox
        }

        // Method to display the array in the ListBox
        private void DisplayArray()
        {
            listBox1.Items.Clear();
            foreach (int value in neutrinoData)
            {
                listBox1.Items.Add(value);
            }
        }

        // Event handler for textBox1_TextChanged
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // ................
        }

        // Event handler for Binary Search (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a value to search for.");
                return;
            }

            int target;
            bool isValid = int.TryParse(textBox1.Text, out target);
            if (!isValid)
            {
                MessageBox.Show("Please enter a valid integer.");
                return;
            }

            // Check if the array is sorted before performing a binary search
            if (!IsSorted(neutrinoData))
            {
                MessageBox.Show("Array is not sorted. Please sort the array before performing a binary search.");
                return;
            }

            int result = BinarySearch(neutrinoData, target);
            if (result != -1)
            {
                // Highlight the found item in the ListBox
                listBox1.SelectedIndex = result;
                MessageBox.Show($"Value {target} found at index {result}.");
            }
            else
            {
                MessageBox.Show("Value not found.");
            }
        }

        // Binary Search algorithm
        private int BinarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1; // Not found
        }

        // Helper method to check if the array is sorted
        private bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    return false; // Array is not sorted
                }
            }
            return true; // Array is sorted
        }

        // Event handler for Bubble Sort (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            BubbleSort(neutrinoData);
            DisplayArray(); // Display sorted array
            MessageBox.Show("Array has been sorted.");
        }

        // Bubble Sort algorithm
        private void BubbleSort(int[] arr)
        {
            // 8 
            // 7
            int n = arr.Length;
            // outer loop
            for (int i = 0; i < n - 1; i++)
            {   // inner loop
                for (int j = 0; j < n - i - 1; j++)

                    // 1 2 3 4 5
                    // 1 3 2 4 5
                {  if (arr[j] > arr[j + 1])
                    {
                  
                        // Swap arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Event handler for ListBox item double-click
        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Check if an item is selected
            if (listBox1.SelectedIndex != -1)
            {
                int selectedIndex = listBox1.SelectedIndex; // Get selected index
                int currentValue = neutrinoData[selectedIndex]; // Get current value

                // Prompt the user for a new value
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Edit value at index {selectedIndex} (current value: {currentValue}):",
                                                                          "Edit Value", currentValue.ToString());

                // Validate the new input
                if (int.TryParse(input, out int newValue))
                {
                    neutrinoData[selectedIndex] = newValue; // Update the array
                    DisplayArray(); // Refresh the ListBox
                    MessageBox.Show($"Value at index {selectedIndex} has been updated to {newValue}.");
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer.");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
