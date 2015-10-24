﻿namespace TrailEntities
{
    /// <summary>
    ///     Abstract class that is intended to be used for working with parts that are extra for the vehicle, once they are
    ///     attached we can monitor their status and individual repair status.
    /// </summary>
    public abstract class PartItem : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:TrailEntities.Item" /> class.
        /// </summary>
        protected PartItem(uint cost, uint quantity) : base(cost, quantity)
        {
        }

        /// <summary>
        ///     Weight of a single item of this type, the original game used pounds so that is roughly what this should represent.
        /// </summary>
        public override uint Weight
        {
            get { return 0; }
        }

        /// <summary>
        ///     Limit on the number of items that are possible to have of this particular type.
        /// </summary>
        public override uint QuantityLimit
        {
            get { return 3; }
        }
    }
}