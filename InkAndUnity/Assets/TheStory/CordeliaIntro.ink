VAR DoorCustomPeek = "Cordelia is getting dressed"
VAR cordeliaIrritated = 0

Joan peeks in the keyhole and sees Cordelia getting dressed.

Joan speaks to her from outside her room.

* Hi, its Joan, the coach.

    Cordelia: Come in!

* You are dressing up, I’ll wait.

    Cordelia: Are you peeking in the keyhole? <b>Don’t do that!</b> Just come in.
    ~ cordeliaIrritated +=2

- 
You enter the room and she is wearing only her boy shorts.

Cordelia: { cordeliaIrritated > 0: Hmph.}{cordeliaIrritated == 0: Hey.} 

Joan looks into camera.
"Shall I leave?"

* Yes
    Outside door.
    [Cordelia now is dressed.]

* No
    Cordelia dresses up.

    Joan: May I come in now?
    Cordelia: Yeeees.

-
* Nice to meet you.

* It’s a pleasure to meet you.
    ~ cordeliaIrritated++ 

-
Cordelia: {cordeliaIrritated > 0: Ok. Um.} 
Cordelia: {cordeliaIrritated==0:  Cool.}

Joan: Is your family happy that you made it to this team?

Cordelia: No, I’m...

Cordelia: There is just my father. Who <b>doesn’t know</b> and <b>doesn’t care</b>.

Joan: Bye!

-> DONE