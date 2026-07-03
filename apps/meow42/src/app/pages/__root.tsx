import * as React from 'react'
import { Outlet, createRootRoute, HeadContent } from '@tanstack/react-router'
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { SideBar } from "../components/Menu/SideBar/SideBar"
import { ContentLayout } from "../components/ContentLayout/ContentLayout"

export const Route = createRootRoute({
  component: RootComponent,
})
const queryClient = new QueryClient();

function RootComponent() {
  return (
    <QueryClientProvider client={queryClient}>
        <SideBar />
            <ContentLayout>
                <HeadContent />
                {/* <StarterObserver /> */}
                <Outlet />
            </ContentLayout>
    </QueryClientProvider>
  )
}
