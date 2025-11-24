# Cadmus Itinera Parts

Components for the _Itinera_ project in Cadmus. This library is derived from <https://github.com/vedph/cadmus_itinera> and will replace it once completed.

All the generic codicological components have been moved to an [independent library](https://github.com/vedph/cadmus-codicology).

## Overview

Itinera domains are:

- persons, mostly Petrarch's correspondents.
- literary texts, mostly letters. Note that currently this does not include the text content, but only information about it.
- manuscripts related to Petrarch's tradition.
- cross-domain bibliography.

This configures 3 items: persons, literary texts, and manuscripts.

## Person Item

Persons belong to the epistolographic area of the project. Most parts here are generic. A person may contain some generic info, any number of names, zero or more identifications, a set of biographic events, a set of works, bibliography, and an optional note.

- [PersonInfoPart](#personinfopart)\*
- [NamesPart](https://github.com/vedph/cadmus-general#namespart)
- [PersonWorksPart](#personworkspart)
- `ExternalIdsPart`
- [HistoricalEventsPart](https://github.com/vedph/cadmus-general#historicaleventspart)
- [ExtBibliographyPart](https://github.com/vedph/cadmus-general#extbibliographypart)
- [NotePart](https://github.com/vedph/cadmus-general#notepart)

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

- [LiteraryWorkInfoPart](literaryworkinfopart)\*
- [LetterInfoPart](#letterinfopart)
- [ChronotopesPart](https://github.com/vedph/cadmus-general#chronotopespart)\*
- [MetadataPart](https://github.com/vedph/cadmus-general#metadatapart)
- `ExternalIdsPart`
- [ReferencedTextsPart](#referencedtextspart)
- [RelatedPersonsPart](#relatedpersonspart) (role=`cited`)
- [RelatedPersonsPart](#relatedpersonspart) (role=`recipients`)
- [WitnessesPart](#witnessespart)
- [ExtBibliographyPart](https://github.com/vedph/cadmus-general#extbibliographypart)
- [NotePart](https://github.com/vedph/cadmus-general#notepart)

### LetterInfoPart

- ID: `it.vedph.itinera.letter-info`

Additional information about a letter.

- subject\* (string)
- header (string)
- textDate (string)

### LiteraryWorkInfoPart

- ID: `it.vedph.itinera.literary-work-info`

Information about the literary work represented by the item.

- authorIds (AssertedCompositeId[])
  - target (PinLinkTarget):
    - gid\* (string)
    - label\* (string)
    - itemId (string)
    - partId (string)
    - partTypeId (string)
    - roleId (string)
    - name (string)
    - value (string)
  - scope (string)
  - tag (string)
  - assertion (Assertion)
- languages\* (string[]) T:literary-work-languages
- genre\* (string) T:literary-work-genres (hierarchical, single choice)
- metres (string[]) T:literary-work-metres
- strophes (string[])
- isLost (boolean)
- titles\* (AssertedTitle[]):
  - language (string) T:literary-work-languages
  - value (string)
  - assertion (Assertion)
- note (string)

>⚠ `authorIds` was of type `AssertedId[]` in versions before 5.

### ReferencedTextsPart

- ID: `it.vedph.itinera.referenced-texts`

Special part about texts referenced by the item's text. This is a list of all the item's text relevant passages which explicitly or implicitly refer to another text.

- texts (ReferencedText[]):
  - type\* (string) T:related-text-types
  - targetId\* (AssertedCompositeId)
  - targetCitation (string)
  - sourceCitations (string[])

### RelatedPersonsPart

- ID: `it.vedph.itinera.related-persons`

Textual labels referencing a person to be identified.

- persons (RelatedPerson[]):
  - type\* (string) T:related-person-types
  - name\* (string)
  - ids\* (AssertedCompositeId[])

>⚠ `ids` was of type `AssertedId[]` in versions before 5.

### WitnessesPart

- ID: `it.vedph.itinera.witnesses`

A list of manuscript witnesses for the work.

- witnesses (Witness[])
  - id\* (string)
  - range\* (CodLocationRange)

## Manuscript Item

Manuscripts mostly use [codicologic parts](https://github.com/vedph/cadmus-codicology), while adding a couple of Itinera-specific parts. Also, they include a number of generic parts.

- [CodBindingsPart](https://github.com/vedph/cadmus-codicology#codbindingspart)
- [CodContentsPart](https://github.com/vedph/cadmus-codicology#codcontentspart)
- [CodDecorationsPart](https://github.com/vedph/cadmus-codicology#coddecorationspart)
- [CodEditsPart](https://github.com/vedph/cadmus-codicology#codeditspart)
- [CodHandsPart](https://github.com/vedph/cadmus-codicology#codhandspart)
- [CodLayoutsPart](https://github.com/vedph/cadmus-codicology#codlayoutspart)
- [CodMaterialDscPart](https://github.com/vedph/cadmus-codicology#codmaterialdscpart)
- [CodSheetLabelsPart](https://github.com/vedph/cadmus-codicology#codsheetlabelspart)
- [CodShelfmarksPart](https://github.com/vedph/cadmus-codicology#codshelfmarkspart)
- [CodWatermarksPart](https://github.com/vedph/cadmus-codicology#codwatermarkspart)
- [CodLociPart](#codlocipart)
- [CodPoemRangesPart](#codpoemrangespart)
- [HistoricalEventsPart](https://github.com/vedph/cadmus-general#historicaleventspart)
- [MetadataPart](https://github.com/vedph/cadmus-general#metadatapart)
- [NotePart](https://github.com/vedph/cadmus-general#notepart) (role=`history`): free text about a manuscript's history.
- [NotePart](https://github.com/vedph/cadmus-general#notepart)
- [ExtBibliographyPart](https://github.com/vedph/cadmus-general#extbibliographypart)

### CodLociPart

- ID: `it.vedph.itinera.cod-loci`

This is specific to Itinera and lists some text passages useful for codicological or philological reasons ("loci critici").

- loci (CodLocus[]):
  - citation\* (string)
  - range\* (CodLocationRange)
  - text\* (string)
  - note (string)
  - images (CodImage[]):
    - id\* (string)
    - type\* (string) T:cod-image-types
    - sourceId (string)
    - label (string)
    - copyright (string)

### CodPoemRangesPart

- ID: `it.vedph.itinera.cod-poem-ranges`

- sortType\* T:cod-poem-range-sort-types
- ranges (AlnumRange[]):
  - a\* (string)
  - b (string)
- layouts (CodPoemLayout[]):
  - range (AlnumRange)
  - layout (string) T:cod-poem-range-layouts
  - note (string)
- tag (string) T:cod-poem-range-tags
- note (string)

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

Once the ranges have been selected by picking them from genres and/or entering them, users must specify the layout for each poem.

## History

### 9.0.0

- 2025-11-24: ⚠️ upgraded to NET 10.

### 8.0.4

- 2025-07-16: updated packages.
- 2025-06-27: updated test packages.

### 8.0.3

- 2025-06-03: updated packages.

### 8.0.2

- 2025-01-29: updated packages.
- 2025-01-06: updated test packages.

### 8.0.1

- 2024-12-06: updated packages.

### 8.0.0

- 2024-11-27: ⚠️ upgraded to .NET 9.

### 7.0.2

- 2024-07-19: updated packages.

### 7.0.1

- 2024-06-24: updated packages.

### 7.0.0

- 2023-12-05: ⚠️ upgraded to NET 8.

### 6.1.1

- 2023-09-25: updated packages.

### 6.1.0

- 2023-09-06: removed redundant `Assertion` from `ReferencedText`. Now the assertion already appears in the asserted composite ID representing the referenced text's target work.

### 6.0.9

- 2023-09-04: updated packages.

### 6.0.8

- 2023-08-29: updated packages.

### 6.0.7

- 2023-08-09: updated packages.

### 6.0.6

- 2023-07-24: updated packages.

### 6.0.5

- 2023-07-17: updated codicology (added `ids` to hand).
- 2023-07-10: updated test packages.

### 6.0.4

- 2023-06-23: updated packages.

### 6.0.3

- 2023-06-21: updated packages.

### 6.0.2

- 2023-06-17: updated packages.

### 6.0.0

- 2023-06-16: updated packages for new PgSql/MySql EF-based components, removing MySql unused references.

### 5.0.3

- 2023-06-02: updated packages.

### 5.0.2

- 2023-05-29: updated packages.

### 5.0.0

- 2023-05-25: updated packages (breaking change in parts introducing [AssertedCompositeId](https://github.com/vedph/cadmus-bricks-shell/blob/master/projects/myrmidon/cadmus-refs-asserted-ids/README.md#asserted-composite-id)):
  - LiteraryWorkInfoPart
  - RelatedPersonsPart

### 4.2.0

- 2023-05-17:
  - updated Codicology packages.
  - added `note` to `CodLocus`.

### 4.1.5

- 2023-05-16: updated packages.

### 4.1.4

- 2023-05-16: updated packages.

### 4.1.3

- 2023-05-12: updated packages.

### 4.1.2

- 2023-04-13: updated packages.

### 4.1.1

- 2023-02-27: updated packages (modified event model in general parts).

### 4.1.0

- 2023-02-27: updated packages (modified event model in general parts).

### 4.0.4

- 2023-02-11: updated geo package.

### 4.0.3

- 2023-02-08: updated Codicology packages.

### 4.0.2

- 2023-02-02: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.

### 3.1.0

- 2023-01-26: replaced author with author IDs in literary work info part.

### 3.0.4

- 2023-01-24: updated packages.

### 3.0.3

- 2023-01-19: added Cadmus geography packages to services.
- 2022-12-22: updated test packages.

### 3.0.1

- 2022-11-30: updated packages.

### 3.0.0

- 2022-11-10: upgraded to NET 7.

### 2.3.3

- 2022-11-05: updated packages.

### 2.3.2

- 2022-11-03: updated packages.

### 2.3.1

- 2022-10-24: updated packages.

### 2.3.0

- 2022-10-10: updated packages for new `IRepositoryProvider`.

### 2.2.9

- 2022-08-26: updated packages.

### 2.2.8

- 2022-08-05: updated packages.

### 2.2.7

- 2022-08-04: updated packages.

### 2.2.6

- 2022-08-04: updated packages.

### 2.2.5

- 2022-08-01: updated packages.

### 2.2.4

- 2022-07-24:
  - nullable projects.
  - changed `Range` to `Ranges` in `Witness`.
  - added `Tag` to `CodPoemRangesPart`.

### 2.2.3

- 2022-06-28: updated packages.

### 2.2.2

- 2022-06-17: updated packages.

### 2.2.1

- 2022-05-19: refactored PoemRanges again.

### 2.2.0

- 2022-05-18: refactored PoemRanges: sortType and note moved into layouts. Updated packages.

### 2.1.2

- 2022-05-08: updated packages and added optional author to literary work info part.
- 2022-04-29: upgraded to NET 6.0.
- 2022-04-12: added `note` to `CodPoemRangesPart`.
- 2022-03-26: upgraded packages.
- 2022-03-05: upgraded packages.
