import { SignedOut, SignInButton, SignedIn, SignOutButton } from '@clerk/clerk-react'
import { createRootRoute, Link, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/router-devtools'

export const Route = createRootRoute({
  component: () => (
    <>
      <div className="p-2 flex gap-2 justify-center
">
        <Link to="/" className="[&.active]:font-bold">
          Home
        </Link>{' '}

        <Link to="/profile" className="[&.active]:font-bold">
          Profile
        </Link>
        <div className=''>
                <SignedOut>
                    <SignInButton />
                </SignedOut>
                <SignedIn>
                    <SignOutButton />
                </SignedIn>
            </div>
      </div>
      <hr />
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
})