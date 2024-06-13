﻿namespace HazzaBot.OutgoingInteraction;

public enum OutgoingInteractionType
{
    // Otherwise known as an interaction callback
    Pong = 1,
    ChannelMessageWithSource = 4,
    DeferredChannelMessageWithSource = 5,
    DeferredUpdateMessage = 6,
    UpdateMessage = 7,
    ApplicationCommandAutocompleteResult = 8,
    Modal = 9,
    PremiumRequired = 10
}