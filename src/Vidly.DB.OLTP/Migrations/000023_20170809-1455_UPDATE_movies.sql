-- <Migration ID="bc27d37e-4dab-430d-adfe-ec7281235018" />
GO
/**************************************************************************
** CREATED BY:   Mick Letofsky
** CREATED DATE: 2017.08.09
** CREATION:     Quick update to the movie details table...
**************************************************************************/
UPDATE dbo.movies 
SET runtime = 94, 
movie_desc = 'Ron Burgundy is San Diego''s top-rated newsman in the male-dominated broadcasting of the 1970s, but that''s all about to change for Ron and his cronies when an ambitious woman is hired as a new anchor.', 
movie_plot_summary = 'In 1970s San Diego, journalism was a well respected profession and people actually cared about what they saw on TV. And the top rated anchor man in the city is Ron Burgundy. He enjoys his run at the top, and has for the last five years. And his news team is equally as good as he is. Professional jock and former professional baseball player Champ Kind handles the sports, the curiously dim witted Brick Tamland - who''s a few channels short of a cable subscription - handles the weather, and ladies'' man Brian Fantana - whose collection of fine scents would be in the Guinness Book Of Records - handles the on-field reporting. But now all that is about to change forever. The TV station Burgundy works for, Channel 4, has embraced diversity and has hired a beautiful new female anchor named Veronica Corningstone. While Ron Burgundy and the rest of the Channel 4 news team enjoys fighting with competitors, drinking, and flirting with the ladies, Veronica quietly climbs her way to the top. And Veronica''s success drives Ron Burgundy crazy. So much that Veronica''s meddling causes Ron to get demoted and ultimately lose his job with Channel 6. Now left with nothing, Ron must find a way to get back to the top - and that involves a story about a rare Chinese panda giving birth on US soil. Will Ron be the one to report the story on a national level?'
WHERE movie_id = 1


UPDATE dbo.movies 
SET runtime = 98, 
movie_desc = 'Two aimless middle-aged losers still living at home are forced against their will to become roommates when their parents marry.', 
movie_plot_summary = 'Brennan Huff and Dale Doback are both about 40 when Brennan''s mom and Dale''s dad marry. The sons still live with the parents so they must now share a room. Initial antipathy threatens the household''s peace and the parents'' relationship. Dad lays down the law: both slackers have a week to find a job. Out of the job search and their love of music comes a pact that leads to friendship but more domestic disarray compounded by the boys'' sleepwalking. Hovering nearby are Brennan''s successful brother and his lonely wife: the brother wants to help sell his step-father''s house, the wife wants Dale''s attention, and the newlyweds want to retire and sail the seven seas. Can harmony come from the discord?'
WHERE movie_id = 2

UPDATE dbo.movies 
SET runtime = 119 , 
movie_desc = 'John Beckwith and Jeremy Grey, a pair of committed womanizers who sneak into weddings to take advantage of the romantic tinge in the air, find themselves at odds with one another when John meets and falls for Claire Cleary.', 
movie_plot_summary = 'Divorce mediators John Beckwith and Jeremy Grey are business partners and lifelong friends who share one truly unique springtime hobby--crashing weddings! Whatever the ethnicity of the wedding party--Jewish, Italian, Irish, Chinese, Hindu--the charismatic and charming duo always have clever back stories for inquisitive guests and inevitably become the hit of every reception, where they strictly adhere to their proven rules of wedding crashing to meet and pick up women aroused by the very thought of marriage. At the tail end of another successful season of toasting brides and grooms, Jeremy learns that the daughter of Treasury Secretary William Cleary and his wife, Kathleen, is getting married in what is sure to be the Washington D.C. social event of the year. After infiltrating the lavish affair, John and Jeremy quickly set their sights on two bridesmaids, Claire and Gloria Cleary. With the lavish reception in full swing, Jeremy works his game plan to perfection in seducing Gloria, but John''s flirtation banter with Claire is unexpectedly impeded by her pompous, Ivy League boyfriend Sack. Having uncharacteristically fallen hard and fast for Claire, John convinces a resistant Jeremy to bend the crashing rules and accept an invitation to an extended weekend party at the Cleary family compound. Once at the palatial waterfront estate, John and Jeremy endure a multitude of comical mishaps at the hands of the dysfunctional members of the Cleary family, but also learn a few unexpected lessons about love and relationships.'
WHERE movie_id = 3

UPDATE dbo.movies 
SET runtime = 88 , 
movie_desc = 'Three friends attempt to recapture their glory days by opening up a fraternity near their alma mater.', 
movie_plot_summary = 'Mitch, Frank and Beanie are disillusioned with their personal lives begining when Mitch''s nymphomanic girlfriend, Heidi, cheats on him, then former party animal Frank gets married, but unwilling to let go of his wild life, and Beanie is a family man seeking to reclaim his wild and crazy youth. Beanie suggests that they form their own fraternity in Mitch''s new house on a college campus to re-live their glory days by bringing together a variety of misfit college students, losers, middle-aged and elderly retirees as their new friends and later try to avoid being evicted by the new Dean of Students, Pritchard, whom still holds a personal grudge against all three of them'
WHERE movie_id = 4

UPDATE dbo.movies 
SET runtime = 92 , 
movie_desc = 'A group of misfits enter a Las Vegas dodgeball tournament in order to save their cherished local gym from the onslaught of a corporate health fitness chain.', 
movie_plot_summary = 'White Goodman (Ben Stiller) is the owner and founder of Globo Gym, and would love nothing more than owning Average Joe''s Gymnasium. Peter LaFleur (Vince Vaughn) doesn''t want to lose his gym to Goodman, but can''t find a way to get $50,000 in time. Peter and his gang of gym buddies think of ways to raise money, finally settling on winning a dodge ball tournament. White Goodman retaliates by creating his own dodge ball team to finish off Peter. Peter''s team doesn''t do too well, until legendary ADAA champ Patches O''Houlihan (Rip Torn) turns up ready to train them.'
WHERE movie_id = 5

UPDATE dbo.movies 
SET runtime = 101 , 
movie_desc = 'An ex-hitman comes out of retirement to track down the gangsters that took everything from him.', 
movie_plot_summary = 'An ex-hitman comes out of retirement to track down the gangsters that took everything from him.'
WHERE movie_id = 6

UPDATE dbo.movies 
SET runtime = 122 , 
movie_desc = 'After returning to the criminal underworld to repay a debt, John Wick discovers that a large bounty has been put on his life.', 
movie_plot_summary = 'After returning to the criminal underworld to repay a debt, John Wick discovers that a large bounty has been put on his life.'
WHERE movie_id = 7
