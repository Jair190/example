﻿namespace OregonTrail
{
    /// <summary>
    ///     Overall health indicator for all entities in the simulation, we do not track health as a numeric value but as a
    ///     enum state that has a roll chance of lowering to the lowest possible state over time.
    /// </summary>
    public enum Condition
    {
        /// <summary>
        ///     Best and starting health of all entities in the simulation.
        /// </summary>
        Good,

        /// <summary>
        ///     Some damage but still good, should reduce stress if possible.
        /// </summary>
        Fair,

        /// <summary>
        ///     Damaged and under-performing, danger of failure.
        /// </summary>
        Bad,

        /// <summary>
        ///     Severe damage, danger of complete failure of death imminent.
        /// </summary>
        Poor,

        /// <summary>
        ///     Destroyed entity, no longer can be used if it is a person they no longer exist.
        /// </summary>
        Dead
    }
}