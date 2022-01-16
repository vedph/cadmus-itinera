# Cadmus Itinera Parts

- [Cadmus Itinera Parts](#cadmus-itinera-parts)
  - [Models](#models)
  - [Person Item](#person-item)
    - [ExternalIdsPart](#externalidspart)
    - [HistoricalEventsPart](#historicaleventspart)
    - [NamesPart](#namespart)
    - [PersonInfoPart](#personinfopart)
    - [PersonWorksPart](#personworkspart)
  - [Literary Text Item](#literary-text-item)
    - [AssertedChronotopesPart](#assertedchronotopespart)
    - [LiteraryWorkInfoPart](#literaryworkinfopart)
    - [ReferencedTextsPart](#referencedtextspart)
    - [RelatedPersonsPart](#relatedpersonspart)
    - [SerialTextInfoPart](#serialtextinfopart)
    - [WitnessesPart](#witnessespart)
  - [Manuscript Item](#manuscript-item)
    - [CodLociPart](#codlocipart)
    - [CodPoemRangesPart](#codpoemrangespart)

Components for the Itinera project in Cadmus. This library is derived from <https://github.com/vedph/cadmus_itinera> and will replace it once completed.

All the codicological components have been moved to an [independent library](https://github.com/vedph/cadmus-codicology).

## Models

## Person Item

Persons belong to the epistolographic area of the project. Most parts here are generic. A person may contain some generic info, any number of names, zero or more identifications, a set of biographic events, a set of works, bibliography, and an optional note.

- PersonInfoPart\*
- NamesPart\*
- ExternalIdsPart
- HistoricalEventsPart
- PersonWorksPart
- ExtBibliographyPart
- NotePart

### ExternalIdsPart

Identifiers assigned to the person. See [general parts](https://github.com/vedph/cadmus-general).

### HistoricalEventsPart

Generic events (including birth and death) linked to a person's biography. See [general parts](https://github.com/vedph/cadmus-general).

### NamesPart

The names assigned to the person. See [general parts](https://github.com/vedph/cadmus-general).

### PersonInfoPart

- ID: `it.vedph.itinera.person-info`

Essential information about a person item. This just contains the sex and a short bio summary. All the key events in the person's life (including birth and death) are modeled as events in the corresponding part.

- sex (string) T:person-sex
- bio (string MD)

### PersonWorksPart

- ID: `it.vedph.itinera.person-works`

The works by a person. This is just a list of work IDs with a conventional title and optional assertion, related to the attribution of the work to the corresponding item.

- works (PersonWork[]):
  - eid (string)
  - title\* (string)
  - assertion (Assertion)

## Literary Text Item

A literary text. Most of its parts are specific to the Itinera project.

- LiteraryWorkInfoPart\*
- AssertedChronotopesPart\*
- ExternalIdsPart
- SerialTextInfoPart
- ReferencedTextsPart
- RelatedPersonsPart (2x, one with role=cited, another with role=recipients)
- ExtBibliographyPart
- NotePart
- WitnessesPart

### AssertedChronotopesPart

Place(s) and date(s) for the work.

- chronotopes\* (AssertedChronotope[])

### LiteraryWorkInfoPart

Information about the literary work represented by the item.

- languages\* (string[]) T:literary-work-languages
- genres (string[]) T:literary-work-genres
- metres (string[]) T:literary-work-metres
- strophes (string[])
- isLost (boolean)
- titles\* (AssertedTitle[]):
  - language (string) T:literary-work-languages
  - value (string)
  - assertion (Assertion)
- note (string)

### ReferencedTextsPart

Special part about texts referenced by the item's text. This is a list of all the item's text relevant passages which explicitly or implicitly refer to another text. 

- texts (ReferencedText[]):
  - type\* (string) T:related-text-types
  - targetId\* (string)
  - targetCitation (string)
  - sourceCitations (string[])
  - assertion (Assertion)

### RelatedPersonsPart

Persons related with the item's text.

- persons (RelatedPerson[]):
  - type\* (string) T:related-person-types
  - targetId\* (string)
  - name\* (string)
  - citation (string)
  - assertion (Assertion)

### SerialTextInfoPart

Special information about a text entering a series of some kind, e.g. a letter replying to another letter, a composition replying to another composition, etc.

- subject\* (string)
- header (string)
- textDate (string)

### WitnessesPart

A list of manuscript witnesses for the work.

- witnesses (Witness[])
  - targetId\* (string)
  - range\* (CodLocationRange)

## Manuscript Item

Manuscripts mostly use [codicologic parts](https://github.com/vedph/cadmus-codicology), while adding a couple of Itinera-specific parts.

### CodLociPart

This is specific to Itinera and lists some text passages useful for codicological or philological reasons ("loci critici").

- loci (CodLocus[]):
  - citation\* (string)
  - range\* (CodLocationRange)
  - text\* (string)
  - images (CodImage[]):
    - id\* (string)
    - type\* (string)
    - sourceId (string)
    - label (string)
    - copyright (string)

### CodPoemRangesPart

- ranges (AlnumRange[]):
  - a\* (string)
  - b (string)
- sortType\* T:cod-poem-range-sort-types
- layouts (CodPoemLayout):
  - range (AlnumRange)
  - layout (string) T:cod-poem-range-layouts

This is specific to Itinera and lists the order in which Petrarch's poems appear in a manuscript. To express this order in a compact yet computable manner, we use a set of alphanumeric ranges, each representing a single poem or a range of poems. The value for each poem starts with a number and may include an alphanumeric suffix after it.

Such values are sorted first by the numeric value of their numeric part, then by the alphanumeric part if any. Values included as edges of a range must be numeric only, because all their intermediate values must be interpolated automatically.

Also, we record the colometries used for these ranges. As the ranges can be grouped by genre (sonetto, canzone, ballata, madrigale, sestina), the UI will allow users to pick a full set of ranges by just selecting a genre. For instance, a user picks "ballata" and this automatically selects poems 11 14 55 59 63 149 324. This is just a way for quickly selecting poems; users can repeat with other groups, or manually add whatever range they prefer.

Genres groups are:

- sonetto: 1-10 12-13 15-21 24-27 31-36 38-49 51 56-58 60-62 64-65 67-69 74-79 81-104 107-118 120 122-124 130-134 136-141
143-148 150-205 208-213 215-236 238 240-263 265-267 269 271-322 326-330 333-358 361-365
- canzone: 23 28-29 37 50 53 70-73 105 119 125-129 135 206-207 264 268 270 323 325 331 359 360 366
- ballata: 11 14 55 59 63 149 324
- madrigale: 52 54 106 121
- sestina: 22 30 66 80 142 214 237 239 332

Each of these poems can have one of these layouts:

- prose
- 1 verse per line
- 2 verses per line
- 3 verses per line

Once the ranges have been selected by picking them from genres and/or entering them, users must specify the layout for each poem in a sort of table, where columns are the 4 layouts, and rows are the poems.
