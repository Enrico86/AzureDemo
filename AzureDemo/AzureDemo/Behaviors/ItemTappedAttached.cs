using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureDemo.Behaviors
{
    public class ItemTappedAttached: Behavior<ListView>
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create
            (
                "ItemTappedCommand",
                typeof(ICommand),
                typeof(ItemTappedAttached),
                null
            );

        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemTappedCommandProperty);
            }

            set 
            { 
                SetValue(ItemTappedCommandProperty, value); 
            }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ItemTappedCommand==null)
            {
                return;
            }
            else
            {
                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                {
                    ItemTappedCommand.Execute(e.SelectedItem);
                }
            }
        }
        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= Bindable_ItemSelected;
        }
    }
}
