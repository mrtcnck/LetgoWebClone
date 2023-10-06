const { algoliasearch, instantsearch } = window;
const { autocomplete } = window['@algolia/autocomplete-js'];
const { createLocalStorageRecentSearchesPlugin } =
    window['@algolia/autocomplete-plugin-recent-searches'];
const { createQuerySuggestionsPlugin } =
    window['@algolia/autocomplete-plugin-query-suggestions'];

const searchClient = algoliasearch(
    'M89XWI1ZIU',
    'd3b732e05ab74a99fa7516464b580122'
);

const search = instantsearch({
    indexName: 'adverts',
    searchClient,
    insights: {
        insightsInitParams: {
            useCookie: true,
        },
    },
});

const virtualSearchBox = instantsearch.connectors.connectSearchBox(() => { });
search.addWidgets([
    virtualSearchBox({}),
    instantsearch.widgets.hits({
        container: '#hits',
        templates: {
            item: (hit, { html, components, sendEvent }) => html`
        <div onClick="${() => window.location.href = "/detay/" + hit.slug}">
          <h1>${components.Highlight({ hit, attribute: 'name' })}</h1>
          <p>${components.Highlight({ hit, attribute: 'description' })}</p>
          <p>${components.Highlight({ hit, attribute: 'price' })}</p>
          <p>${components.Highlight({ hit, attribute: 'slug' })}</p>
          <p>${components.Highlight({ hit, attribute: 'creationDate' })}</p> 
          <p>${components.Highlight({ hit, attribute: 'image' })}</p> 
          <img src="${hit.image}" style="width:50px;"/>
        </div>
      `,
        }
    }),
    instantsearch.widgets.configure({
        hitsPerPage: 3,
        distinct: true,
        clickAnalytics: true,
        enablePersonalization: true
    }),
    instantsearch.widgets.dynamicWidgets({
        container: '#dynamic-widgets',
        fallbackWidget({ container, attribute }) {
            return instantsearch.widgets.panel({
                templates: { header: () => attribute },
            })(instantsearch.widgets.refinementList)({
                container,
                attribute,
            });
        },
        widgets: [],
    }),
    instantsearch.widgets.pagination({
        container: '#pagination',
       
    }),
    
]);

search.start();

const recentSearchesPlugin = createLocalStorageRecentSearchesPlugin({
    key: 'instantsearch',
    limit: 3,
    transformSource({ source }) {
        return {
            ...source,
            onSelect({ setIsOpen, setQuery, item, event }) {
                onSelect({ setQuery, setIsOpen, event, query: item.label });
            },
        };
    },
});

const querySuggestionsPlugin = createQuerySuggestionsPlugin({
    searchClient,
    indexName: 'instant_search_demo_query_suggestions',
    getSearchParams() {
        return recentSearchesPlugin.data.getAlgoliaSearchParams({ hitsPerPage: 6 });
    },
    transformSource({ source }) {
        return {
            ...source,
            sourceId: 'querySuggestionsPlugin',
            onSelect({ setIsOpen, setQuery, event, item }) {
                onSelect({ setQuery, setIsOpen, event, query: item.query });
            },
            getItems(params) {
                if (!params.state.query) {
                    return [];
                }

                return source.getItems(params);
            },
        };
    },
});

autocomplete({
    container: '#searchbox',
    openOnFocus: true,
    detachedMediaQuery: 'none',
    onSubmit({ state }) {
        setInstantSearchUiState({ query: state.query });
    },
    plugins: [recentSearchesPlugin, querySuggestionsPlugin],
});

function setInstantSearchUiState(indexUiState) {
    search.mainIndex.setIndexUiState({ page: 1, ...indexUiState });
}

function onSelect({ setIsOpen, setQuery, event, query }) {
    if (isModifierEvent(event)) {
        return;
    }

    setQuery(query);
    setIsOpen(false);
    setInstantSearchUiState({ query });
}

function isModifierEvent(event) {
    const isMiddleClick = event.button === 1;

    return (
        isMiddleClick ||
        event.altKey ||
        event.ctrlKey ||
        event.metaKey ||
        event.shiftKey
    );
}



