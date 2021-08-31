using System;
using Xamarin.Forms;

namespace CursoXamarin.Views.Behavior
{
    public class BindableBehavior<T> : Behavior<T> where T : BindableObject
    {

        public T AssociatedObject { get; private set; }

        public BindableBehavior()
        {
        }
    }
}
