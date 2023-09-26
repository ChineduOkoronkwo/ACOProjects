GRANT ALL
ON ALL TABLES
IN SCHEMA "public"
TO testuser;

CREATE TABLE Country (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Alpha2 CHAR(2) NOT NULL,
    Alpha3 CHAR(3) NOT NULL,
    CountryCode Varchar(3) NOT NULL,
    Region VARCHAR(50),
    SubRegion VARCHAR(50),
    IntermediateRegion VARCHAR(50),
    RegionCode VARCHAR(50),
    SubRegionCode VARCHAR(50),
    IntermediateRegionCode VARCHAR(50)
);

CREATE TABLE Team (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CountryId UUID NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Country(id)
);

CREATE TABLE League (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CountryId UUID NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Country(id)
);

CREATE TABLE SEASON (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CountryId UUID NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE Not NULL,
    FOREIGN KEY (CountryId) REFERENCES Country(id)
);

CREATE TABLE LeagueTeam (
    Id UUID PRIMARY KEY,
    SeasonId UUID NOT NULL,
    LeagueId UUID NOT NULL,
    TeamId UUID NOT NULL,
    FOREIGN KEY (SeasonId) REFERENCES Season(id),
    FOREIGN KEY (LeagueId) REFERENCES League(id),
    FOREIGN KEY (TeamId) REFERENCES Team(id)
);

CREATE TABLE Status (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE MatchRound (
    Id UUID PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE Fixture (
    Id UUID PRIMARY KEY,
    HomeLeagueTeamId UUID NOT NULL,
    AwayLeagueTeamId UUID NOT NULL,
    MatchDateTime TIMESTAMP NOT NULL,
    MatchRoundId UUID NOT NULL,
    StatusId UUID NOT NULL,
    FOREIGN KEY (MatchRoundId) REFERENCES MatchRound(id),
    FOREIGN KEY (StatusId) REFERENCES Status(id),
    FOREIGN KEY (HomeLeagueTeamId) REFERENCES LeagueTeam(id),
    FOREIGN KEY (AwayLeagueTeamId) REFERENCES LeagueTeam(id)
);

CREATE TABLE FixtureResult (
    Id UUID PRIMARY KEY,
    FixtureId UUID NOT NULL,
    HomeLeagueTeamScore INT NOT NULL,
    AwayLeagueTeamScore INT NOT NULL,
    FOREIGN KEY (FixtureId) REFERENCES Fixture(id)
);

CREATE UNIQUE INDEX idx_unique_league_team_seasonId_TeamId ON LeagueTeam (SeasonId, TeamId);

CREATE OR REPLACE FUNCTION check_league_team_country()
RETURNS TRIGGER AS $$
DECLARE team_country_id UUID;
BEGIN
    SELECT CountryId INTO team_country_id FROM Team WHERE TeamId = NEW.TeamId;

    IF team_country_id != (SELECT CountryId FROM League WHERE LeagueId = NEW.LeagueId) OR
    team_country_id != (SELECT CountryId FROM Season WHERE SeasonId = NEW.SeasonId) THEN
        RAISE EXCEPTION 'The league, season, and team must have the same country.';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER enforce_league_team_country
BEFORE INSERT OR UPDATE ON LeagueTeam
FOR EACH ROW
EXECUTE FUNCTION check_league_team_country();

CREATE OR REPLACE FUNCTION check_fixture_league()
RETURNS TRIGGER AS $$
BEGIN
    IF (SELECT SeasonId::text || LeagueId::text FROM LeagueTeam WHERE id = NEW.HomeLeagueTeamId) !=
    (SELECT SeasonId::text || LeagueId::text FROM LeagueTeam WHERE id = NEW.AwayLeagueTeamId) THEN
        RAISE EXCEPTION 'The home team and away team must be from the same league and season.';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER enforce_fixture_league
BEFORE INSERT OR UPDATE ON Fixture
FOR EACH ROW
EXECUTE FUNCTION check_fixture_league();