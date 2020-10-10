/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace mhed.lib
{
    /// <summary>
    /// Provides a generic collection that supports data binding and sorting.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public sealed class SortableBindingList<T> : BindingList<T> where T : class
    {
        /// <summary>
        /// Stores the direction the list is sorted.
        /// </summary>
        private ListSortDirection SortDirection = ListSortDirection.Ascending;

        /// <summary>
        /// Stores the property descriptor that is used for sorting the list.
        /// </summary>
        private PropertyDescriptor SortProperty = null;

        /// <summary>
        /// Stores a value indicating whether the list is sorted.
        /// </summary>
        private bool IsSorted = false;

        /// <summary>
        /// Compares two items from the list.
        /// </summary>
        /// <param name="Left">Left item.</param>
        /// <param name="Right">Right item.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        private int Compare(T Left, T Right)
        {
            int Result = CompareValues(Left == null ? null : SortProperty.GetValue(Left), Right == null ? null : SortProperty.GetValue(Right));
            return SortDirection == ListSortDirection.Descending ? -Result : Result;
        }

        /// <summary>
        /// Compares the values of two items from the list.
        /// </summary>
        /// <param name="LeftValue">Left item's value.</param>
        /// <param name="RightValue">Right item's value.</param>
        /// <returns>New relative order.</returns>
        private int CompareValues(object LeftValue, object RightValue)
        {
            if (LeftValue == null) return RightValue == null ? 0 : -1;
            if (RightValue == null) return 1;
            if (LeftValue.Equals(RightValue)) return 0;
            if (LeftValue is IComparable LeftValueComparable) return LeftValueComparable.CompareTo(RightValue);
            return LeftValue.ToString().CompareTo(RightValue.ToString());
        }

        /// <summary>
        /// Sends a report to all subscribers when the list changes.
        /// </summary>
        private void ReportListChange()
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore => SortDirection;

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting
        /// is implemented in a derived class; otherwise, returns null.
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore => SortProperty;

        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore => IsSorted;

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore => true;

        /// <summary>
        /// Sorts the items in the list.
        /// </summary>
        /// <param name="prop">A PropertyDescriptor that specifies the property to sort on.</param>
        /// <param name="direction">One of the ListSortDirection values.</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (!(Items is List<T> Source)) return;
            SortDirection = direction;
            SortProperty = prop;
            Source.Sort(Compare);
            IsSorted = true;
            ReportListChange();
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore.
        /// </summary>
        protected override void RemoveSortCore()
        {
            SortDirection = ListSortDirection.Ascending;
            SortProperty = null;
            IsSorted = false;
        }
    }
}
