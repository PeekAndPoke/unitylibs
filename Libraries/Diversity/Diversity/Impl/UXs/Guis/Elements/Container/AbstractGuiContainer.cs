using System.Collections.Generic;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container
{
    /// <summary>
    /// Base implementation of all containers
    /// </summary>
    /// <typeparam name="TContainerType"></typeparam>
    abstract public class AbstractGuiContainer<TContainerType> : GenericAbstractGuiElement<TContainerType>, IGuiElementContainer
        where TContainerType : IGuiElementContainer
    {
        /// <summary>
        /// The child elements
        /// </summary>
        private readonly List<IGuiElement> _children = new List<IGuiElement>();
        
        /// <summary>
        /// C'tor
        /// </summary>
        protected AbstractGuiContainer()
        {
            SetLayout(new ContainerLayout(this));
        }

        /// <summary>
        /// Get all child gui elements
        /// </summary>
        /// <returns>
        /// The children
        /// </returns>
        public List<IGuiElement> GetChildren()
        {
            return _children;
        }

        /// <summary>
        /// Set the stage on the container and all its children.
        /// </summary>
        /// <param name="stage"></param>
        public override void SetStage(GuiStage stage)
        {
            base.SetStage(stage);

            foreach (var child in GetChildren())
            {
                child.SetStage(stage);
            }
        }

        /// <summary>
        /// tweenable padding
        /// </summary>
        public float Padding
        {
            get { return GetLayout().Padding; }
            set { GetLayout().Padding = value; }
        }

        /// <summary>
        /// Sets the padding of the container
        /// </summary>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        /// <returns></returns>
        public TContainerType SetPadding(float top, float right, float bottom, float left)
        {
            GetLayout().SetPadding(top, right, bottom, left);
            return AsElementType();
        }

        /// <summary>
        /// Draws the container and its children
        /// </summary>
        public override void Draw(IRenderer renderer)
        {
            base.Draw(renderer);

            DrawChildren(renderer);
        }

        /// <summary>
        /// Draws all children that are visible
        /// </summary>
        protected void DrawChildren(IRenderer renderer)
        {
            foreach (IGuiElement child in GetChildren())
            {
                if (child.GetLayout().Visible)
                {
                    child.Draw(renderer);
                }
            }
        }

        /// <summary>
        /// Add a child
        /// </summary>
        /// <param name="child">The element to add</param>
        /// <returns></returns>
        public void AddChild(IGuiElement child)
        {
            // is it allready a child of ours?
            if (!_children.Contains(child))
            {
                _children.Add(child);
                EnsureParent(child);

                child.SetStage(GetStage());
            }
        }

        /// <summary>
        /// Ensures that the parent is corret and that the child is not child of another container anymore.
        /// </summary>
        /// <param name="child"></param>
        protected void EnsureParent(IGuiElement child)
        {
            if (child.GetParent() != null)
            {
                child.GetParent().RemoveChild(child);
            }

            child.SetParent(this);
        }

        /// <summary>
        /// Replace a child with another gui element.
        /// If 'which' is no child nothing is done.
        /// </summary>
        /// <param name="which">which child to remove</param>
        /// <param name="with">to replace with</param>
        /// <param name="destroyRemoved">true to destroy the removed child</param>
        /// <see cref="IGuiElement.Destroy" />
        public void ReplaceChild(IGuiElement which, IGuiElement with, bool destroyRemoved = false)
        {
            if (HasChild(which))
            {
                var index = _children.IndexOf(which);

                _children[index] = with;
                EnsureParent(with);

                with.SetStage(GetStage());

                which.SetParent(null);
                which.SetStage(null);

                if (destroyRemoved)
                {
                    which.Destroy();
                }
            }
        }

        /// <summary>
        /// Removes the child.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="destroy">if set to <c>true</c> [destroy].</param>
        public void RemoveChild(IGuiElement component, bool destroy = false)
        {
            if (HasChild(component))
            {
                // NOTICE: RemovedFromStage is dispatch in SetStage() for the component and all its children
                // @see SetStage() of the this class and of AbstractGuiElement

                _children.Remove(component);
                component.SetParent(null);
                component.SetStage(null);

                if (destroy)
                {
                    component.Destroy();
                }
            }
        }

        /// <summary>
        /// Destroy the gui element.
        /// Removes all behaviours and event listeners.
        /// After it is destroy it can not be used again, meaning it must not be added to the stage again.
        /// </summary>
        public override void Destroy()
        {
            // destroy all children
            foreach (var child in _children)
            {
                child.Destroy();
            }

            base.Destroy();
        }

        /// <summary>
        /// Remove a child at the given index.
        /// If the index is greater or equal the number of children or less than 0 nothing is done.
        /// </summary>
        /// <param name="idx">The index</param>
        /// <param name="destroy">True to detroy the child after removal.</param>
        /// <see cref="IGuiElement.Destroy" />
        public void RemoveChildAt(int idx, bool destroy = false)
        {
            if (idx >= 0 && idx < _children.Count)
            {
                RemoveChild(_children[idx], destroy);
            }
        }

        /// <summary>
        /// Remove all children
        /// </summary>
        /// <param name="destroy">True to destroy each child after removal.</param>
        public void RemoveAllChildren(bool destroy = false)
        {
            while (_children.Count > 0)
            {
                RemoveChildAt(0, destroy);
            }
        }

        /// <summary>
        /// Determines whether the specified component has child.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>
        ///   <c>true</c> if the specified component has child; otherwise, <c>false</c>.
        /// </returns>
        public bool HasChild(IGuiElement component)
        {
            return _children.Contains(component);
        }
    }
}
