import { StrictMode } from 'react';
import * as ReactDOM from 'react-dom/client';
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { routeTree } from "./app/route-tree.gen.ts";
import { App } from './app/app';

export const router = createRouter({
    routeTree,
    defaultPreload: "intent",
    scrollRestoration: true,
});
export type AppRouter = typeof router;

declare module "@tanstack/react-router" {
    interface Register {
        router: typeof router;
    }
}

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);

root.render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
);
