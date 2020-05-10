## Gameplay:

### Overview:

Game is played on a 4x4 tile grid. At the start of the game, blockers are placed
on 1-6 of the tiles randomly. Cards cannot be played on those tiles.

Players start with 5 cards in their hand.
The game ends when both players have 0 cards left in their hand.
The winner is decided by who has more cards left under their control when
the game ends.

### Gameplay Loop:

Each player can play 0-1 cards on their turn. The cards can be played on any
open tile. Players do not HAVE to play a card on their turn.

Some cards have special abilities which can be activated through the course
of the game. Each card's ability may only be activated once, and only one
ability may be used per turn.

After each player has concluded playing cards and abilities, the combat phase
commences. During the combat phase, all of the cards on the board that are
currently owned by the player whose turn it is will take turns attacking.

The order of attacks is always in reverse chronological order (the most 
recently played card's attack happens first, the very first played card's
attack happens last).

Cards will damage enemy cards in adjacent tiles only if the attacking card 
has an arrow pointing at the tile.

When a card is damaged such that its health reaches 0, control of the card
passes to the attacker. Its health is reset to 1.

Alternate possibility: That card is just out of the game and can't be targeted
by any attacks or special abilities and no longer counts toward the player's
number of cards for deciding who wins/loses.

In the event that a player places their last remaining card, they are no
longer allowed to take their turn - including using any special abilities. The
player's cards will continue to attack on their own when their turn would have
happened.

The opponent may continue taking turns until they have played their final card.

### Damage Calculation:

If the defending card does NOT have an arrow pointing back at the attacking card,
the defending card takes normal damage.

If the defending card DOES have an arrow pointing back at the attacking card,
the defending card takes 75% damage.

If the defending card's type is weak to the attacking card's type, the defending
card takes 125% damage.

If the defending card's type is strong against the attacking card's type, the
defending card takes 75% damage.

If the defending card's type is equal to the attacking card's type, the defending
card takes normal damage.

These values DO stack: For example, if a defending card's type is strong against
the attacking card's type AND the defending card has an arrow pointing back at the
attacking card, the defending card takes 56% (75% of 75%) damage.

A defending card will always take at least 1 damage per turn.

## Stretch Goals and Stuff to be Decided Later:

What will the special abilities look like?

Ideas:
- Some cards have no abilities
- Swap two cards on the board
- Reset a card's ability
- Return a card to the hand
- Restore a card's health to full
- Increase a card's Attack / Defense / Health

What happens when a card's health reaches 0?

Is there a time or round limit on the game?

Perhaps we could go FF12 style and impose procedural "rules" onto each game.

Rule Ideas:
- No card abilities
- 10 turn max
- Knock-Out / Takeover
- Reduced/Increased hand size
- No blockers / Extra Blockers
- Place more than one card per turn