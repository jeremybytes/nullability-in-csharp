﻿using System.Windows;
using UsingTask.Library;
using UsingTask.Shared;

namespace UsingTask.UI;

public partial class MainWindow : Window
{
    private PersonReader? reader;
    public PersonReader Reader
    {
        //get
        //{
        //    if (reader is null)
        //        reader = new PersonReader();
        //    return reader;
        //}

        //get
        //{
        //    reader = reader ?? new PersonReader();
        //    return reader;
        //}

        //get
        //{
        //    reader ??= new PersonReader();
        //    return reader;
        //}

        //get { return reader ??= new PersonReader(); }

        get => reader ??= new PersonReader();
        set => reader = value; 
    }

    CancellationTokenSource? tokenSource;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithTaskButton.IsEnabled = false;
        ClearListBox();

        Task<List<Person>> peopleTask = Reader.GetAsync(tokenSource.Token);
        peopleTask.ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                if (task.Exception is not null)
                {
                    foreach (var ex in task.Exception.Flatten().InnerExceptions)
                        MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
                }

                //foreach (var ex in task!.Exception.Flatten().InnerExceptions)
                //    MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
            }
            if (task.IsCanceled)
            {
                MessageBox.Show("CANCELED");
            }
            if (task.IsCompletedSuccessfully)
            {
                List<Person> people = task.Result;
                foreach (var person in people)
                    PersonListBox.Items.Add(person);
            }
            FetchWithTaskButton.IsEnabled = true;
        },
        TaskScheduler.FromCurrentSynchronizationContext());
    }

    private async void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource = new CancellationTokenSource();
        FetchWithAwaitButton.IsEnabled = false;
        try
        {
            ClearListBox();

            List<Person> people = await Reader.GetAsync(tokenSource.Token);
            foreach (var person in people)
                PersonListBox.Items.Add(person);
        }
        catch (OperationCanceledException ex)
        {
            MessageBox.Show($"CANCELED\n{ex.GetType()}\n{ex.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"ERROR\n{ex.GetType()}\n{ex.Message}");
        }
        finally
        {
            FetchWithAwaitButton.IsEnabled = true;
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        //if (tokenSource is not null)
        //    tokenSource.Cancel();

        tokenSource?.Cancel();
    }

    private void ClearListBox()
    {
        PersonListBox.Items.Clear();
    }
}
