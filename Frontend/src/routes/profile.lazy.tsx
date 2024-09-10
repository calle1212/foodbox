import { createLazyFileRoute } from '@tanstack/react-router'
import ProfilePage from '../components/ProfilePage'

export const Route = createLazyFileRoute('/profile')({
  component: ProfilePage
})