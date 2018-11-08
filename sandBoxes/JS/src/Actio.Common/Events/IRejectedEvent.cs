namespace Actio.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        /// <summary>
        /// The reason for rejecting the event
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// The rejection code
        /// </summary>
        string Code { get; }
    }
}
