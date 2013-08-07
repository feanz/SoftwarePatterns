using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using SoftwarePatterns.Core.Momento;

namespace SoftwarePatterns.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly Stack<IMemento> priorStates = new Stack<IMemento>();

		public MainWindow()
		{
			InitializeComponent();

			CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo,
				OnExectedCommands));

			Canvas1.MouseUp += Canvas1OnMouseUp;
			StoreState();
		}

		private void Canvas1OnMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			StoreState();
		}

		private void OnExectedCommands(object sender, ExecutedRoutedEventArgs e)
		{
			var window = (MainWindow) sender;
			if (e.Command == ApplicationCommands.Undo)
			{
				window.Undo(sender, e);
			}
		}

		private void Undo(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
		{
			if (priorStates.Count > 1)
			{
				priorStates.Pop();
				var lastState = priorStates.Peek();
				Canvas1.SetMemento(lastState);
			}
			Label1.Content = priorStates.Count;
		}

		private void StoreState()
		{
			var memento = Canvas1.CreateMemento();
			priorStates.Push(memento);
			Label1.Content = priorStates.Count;
		}
	}

	public class InkCanvasWithUndo : InkCanvas
	{
		public IMemento CreateMemento()
		{
			var copy = Strokes.ToArray();
			return new InkCanvasMemeto { State = copy };
		}

		public void SetMemento(IMemento memento)
		{
			Strokes = new StrokeCollection((Stroke[])memento.State);
		}
	}
}
